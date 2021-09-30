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
    public class EmployeeTeamController : ControllerBase
    {
        private readonly IEmployeeTeamService _service;
        private readonly IMapper _mapper;

        public EmployeeTeamController(IEmployeeTeamService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeTeam>>> Get([FromQuery]EmployeeTeamSearchRequest search)
        {
            return Ok(await _service.Get(search));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeTeam>> GetByID(int id)
        {

            return Ok(await _service.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<EmployeeTeam>> Insert(EmployeeTeamRestUpsertModel request)
        {
            var insertRequest = _mapper.Map<EmployeeTeamInsertRequest>(request);
            insertRequest.CreatedUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            insertRequest.CreatedDate = DateTime.Now;
            return Ok(await _service.Insert(insertRequest));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeTeam>> Update(int id, EmployeeTeamRestUpsertModel request)
        {
            var insertRequest = _mapper.Map<EmployeeTeamUpdateRequest>(request);
            insertRequest.ModifiedUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            insertRequest.ModifiedDate = DateTime.Now;
            return Ok(await _service.Update(id,insertRequest));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeTeam>>Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
