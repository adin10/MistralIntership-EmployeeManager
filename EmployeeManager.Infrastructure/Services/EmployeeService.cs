using AutoMapper;
using EmployeeManager.Common;
using EmployeeManager.Database;
using EmployeeManager.Infrastructure.Context;
using EmployeeManager.Infrastructure.Requests;
using EmployeeManager.Infrastructure.Response;
using EmployeeManager.Infrastructure.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly IPasswordHasher<IdentityUser<int>> _passwordHasher;
        private readonly IPasswordValidator<IdentityUser<int>> _passwordValidator;

        public EmployeeService(
            MyContext context, 
            IMapper mapper, 
            UserManager<IdentityUser<int>> userManager,
            IPasswordHasher<IdentityUser<int>> passwordHasher,
            IPasswordValidator<IdentityUser<int>> passwordValidator
            )
        {
            _context = context;
            _mapper = mapper;
            this._userManager = userManager;
            this._passwordHasher = passwordHasher;
            this._passwordValidator = passwordValidator;
        }

        public async Task<Employee> Delete(int id)
        {
            var entity =await _context.Employee.FindAsync(id);
            _context.Employee.Remove(entity);
           await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<EmployeeResponse>> Get(EmployeeSearchRequest search)
        {
       
            var query= _context.Employee.AsQueryable();
            if (search != null)
            {
                if (search.UserID.HasValue)
                {
                    query = query.Where(q => q.UserID == search.UserID);
                }
                if (!string.IsNullOrWhiteSpace(search.FirstName))
                {
                    var normalizedEmployeeName = search.FirstName.ToLower();
                    query = query.Where(q => q.FirstName.ToLower().Contains(normalizedEmployeeName));
                }
                if (!string.IsNullOrWhiteSpace(search.LastName))
                {
                    var normalizedEmployeeLastName = search.LastName.ToLower();
                    query = query.Where(q => q.LastName.ToLower().Contains(normalizedEmployeeLastName));
                }
            }
            var list =await query.ToListAsync();
            return _mapper.Map<List<EmployeeResponse>>(list);
        }

        public async Task<EmployeeResponse> GetByID(int id)
        {
            var result = await _context.Employee.Include(x => x.User).Include(x=>x.EmployeeTeams).FirstOrDefaultAsync(x => x.EmployeeID == id);
            return _mapper.Map<EmployeeResponse>(result);
        }

        public async Task<Employee> Insert(EmployeeInsertRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try

            {
                // dodavanje user
                var user = _mapper.Map<IdentityUser<int>>(request.User);
                var result = await _userManager.CreateAsync(user, request.User.Password);
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                await _userManager.AddToRoleAsync(user, Role.Employee.ToString());


                // dodavanje employee

                var entity = _mapper.Map<Employee>(request);
                entity.User = user;

                await _context.Employee.AddAsync(entity);
                await _context.SaveChangesAsync();

                //_____________________________________________________________________________________________________-

                // dodavanje employeeTeam
                var employeeTeam = _mapper.Map<List<EmployeeTeam>>(request.Teams);
                employeeTeam.ForEach(x => x.Employee = entity);
                await _context.EmployeeTeam.AddRangeAsync(employeeTeam);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return entity;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }

            //var result = await _passwordValidator.ValidateAsync(_userManager, user, request.User.Password);
            //if (!result.Succeeded)
            //{
            //    throw new Exception("Password does not match with password policy.");
            //}
            //user.PasswordHash = _passwordHasher.HashPassword(user, request.User.Password);
            //await _userManager.CreateAsync(user);
        }
        public async Task<Employee> Update(int id, EmployeeUpdateRequest request)
        {

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var entity = await _context.Employee.FindAsync(id);
                var user = await _userManager.FindByIdAsync(entity.UserID.ToString());
                if (!string.IsNullOrEmpty(request.User.Password))
                {
                    var result = await _userManager.ChangePasswordAsync(user, request.User.CurrentPassword, request.User.Password);
                    if(!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                }
                _mapper.Map(request.User, user);
                var userUpdateResult = await _userManager.UpdateAsync(user);
                if (!userUpdateResult.Succeeded)
                {
                    throw new Exception(userUpdateResult.Errors.First().Description);
                }

                _mapper.Map(request, entity);
                await _context.SaveChangesAsync();

                var teams = await _context.EmployeeTeam.Where(x => x.EmployeeID == id).ToListAsync();
                
                var teamsToAdd = _mapper.Map<List<EmployeeTeam>>(request.Teams.Where(x => !teams.Any(y => y.TeamID == x.TeamID)));
                teamsToAdd.ForEach(x => {
                    x.Employee = entity;
                    x.CreatedDate = DateTime.Now;
                    x.CreatedUserId = entity.CreatedUserId;
                });
                await _context.EmployeeTeam.AddRangeAsync(teamsToAdd);
                var teasmsToDelete = teams.Where(x => !request.Teams.Any(y => y.TeamID == x.TeamID)).ToList();
                _context.EmployeeTeam.RemoveRange(teasmsToDelete);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return entity;
            }

            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
