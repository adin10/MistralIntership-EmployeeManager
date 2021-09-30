using AutoMapper;
using EmployeeManager.API.Models;
using EmployeeManager.Database;
using EmployeeManager.Infrastructure.Requests;
using EmployeeManager.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTeamController : ControllerBase
    {
        private readonly IProjectTeamService _service;
        private readonly IMapper _mapper;

        public ProjectTeamController(IProjectTeamService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectTeam>>> Get([FromQuery] ProjectTeamSearchRequest request)
        {
            return Ok(await _service.Get(request));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectTeam>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ProjectTeam>> Insert( ProjectTeamRestUpsertModel request)
        {
            var insertRequest = _mapper.Map<ProjectTeamInsertRequest>(request);
            insertRequest.CreatedUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            insertRequest.CreatedDate = DateTime.Now;
            return Ok(await _service.Insert(insertRequest));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProjectTeam>> Update(int id, ProjectTeamRestUpsertModel request)
        {
            var updateRequest = _mapper.Map<ProjectTeamUpdateRequest>(request);
            updateRequest.ModifiedUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            updateRequest.ModifiedDate = DateTime.Now;
            return Ok(await _service.Update(id, updateRequest));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectTeam>>Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
