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
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _service;
        private readonly IMapper _mapper;

        public TeamController(ITeamService service, IMapper mapper)
        {
            _service = service;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeamResponse>>> Get([FromQuery] TeamSearchRequest searchRequest)
        {
            return Ok(await _service.Get(searchRequest));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetByID(int id)
        {
            return Ok(await _service.GetByID(id));
        }
        [HttpPost]
        public async Task<ActionResult<Team>> Insert(TeamRestUpsertModel request)
        {
            var insertRequest = _mapper.Map<TeamInsertRequest>(request);
            insertRequest.CreatedUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            insertRequest.CreatedDate = DateTime.Now;
            return Ok(await _service.Insert(insertRequest));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Team>> Update(int id, TeamRestUpsertModel  request)
        {
            var updateRequest = _mapper.Map<TeamUpdateRequest>(request);
            updateRequest.ModifiedUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            updateRequest.ModifiedDate = DateTime.Now;
            return Ok(await _service.Update(id, updateRequest));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Team>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
