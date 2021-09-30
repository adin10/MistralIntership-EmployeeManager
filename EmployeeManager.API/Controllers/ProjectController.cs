using AutoMapper;
using EmployeeManager.API.Models;
using EmployeeManager.Database;
using EmployeeManager.Infrastructure.Requests;
using EmployeeManager.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EmployeeManager.Infrastructure.Response;

namespace EmployeeManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProjectResponse>>> Get([FromQuery]ProjectSearchRequest search)
        {
            return Ok(await _service.Get(search));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectResponse>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Project>> Insert(ProjectRestUpsertModel request)
        {
            var insertRequest = _mapper.Map<ProjectInsertRequest>(request);
            insertRequest.CreatedUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            insertRequest.CreatedDate = DateTime.Now;
            insertRequest.Teams?.ForEach(x => { x.CreatedDate = DateTime.Now; x.CreatedUserId = insertRequest.CreatedUserId; });
            return Ok(await _service.Insert(insertRequest));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> Update(int id, ProjectRestUpsertModel request)
        {
            var updateRequest = _mapper.Map<ProjectUpdateRequest>(request);
            updateRequest.ModifiedUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            updateRequest.ModifiedDate = DateTime.Now;
            updateRequest.Teams?.ForEach(x => { x.ModifiedDate = DateTime.Now; x.ModifiedUserId = updateRequest.ModifiedUserId; });
            return Ok(await _service.Update(id, updateRequest));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>>Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
