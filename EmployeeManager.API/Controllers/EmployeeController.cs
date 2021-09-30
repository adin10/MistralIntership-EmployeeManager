using AutoMapper;
using EmployeeManager.API.Models;
using EmployeeManager.Database;
using EmployeeManager.Infrastructure.Requests;
using EmployeeManager.Infrastructure.Response;
using EmployeeManager.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeResponse>>> Get([FromQuery]EmployeeSearchRequest searchRequest)
        {
            return Ok(await _service.Get(searchRequest));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeResponse>> GetByID(int id)
        {
            return Ok(await _service.GetByID(id));
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> Insert(EmployeeRestUpsertModel request)
        {
            //HttpContext.Request.Form.Files
            //var files = HttpContext.Request.Form.Files;
            var insertRequest = _mapper.Map<EmployeeInsertRequest>(request);
            insertRequest.CreatedUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            insertRequest.CreatedDate = DateTime.Now;
            insertRequest.Teams?.ForEach(x => { x.CreatedDate = DateTime.Now; x.CreatedUserId = insertRequest.CreatedUserId; });
            return Ok(await _service.Insert(insertRequest));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> Update(int id, EmployeeUpdateRestUpsertModel request)
        {
            var updateRequest = _mapper.Map<EmployeeUpdateRequest>(request);
            updateRequest.ModifiedUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            updateRequest.ModifiedDate = DateTime.Now;
            updateRequest.Teams?.ForEach(x => { x.ModifiedDate = DateTime.Now; x.ModifiedUserId = updateRequest.ModifiedUserId; });
            return Ok(await _service.Update(id, updateRequest));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>>Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
