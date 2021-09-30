using AutoMapper;
using EmployeeManager.API.Models;
using EmployeeManager.Database;
using EmployeeManager.Infrastructure.Requests;
using EmployeeManager.Infrastructure.Response;
using EmployeeManager.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin, Employee")]
    public class TrackingController : ControllerBase
    {
        private readonly ITrackingService _service;
        private readonly IMapper _mapper;

        public TrackingController(ITrackingService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<TrackingResponse>>> get()
        {
            return Ok(await _service.get());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TrackingResponse>> GetById(int id)
        {
            return Ok(await _service.GetByID(id));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tracking>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }

        [HttpPost]
        public async Task<ActionResult<Tracking>> Insert(TrackingRestUpsertModel request)
        {
            var insertRequest = _mapper.Map<TrackingInsertRequest>(request);
            insertRequest.CreatedUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            insertRequest.CreatedDate = DateTime.Now;
            return Ok(await _service.Insert(insertRequest));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Tracking>>Update(int id,TrackingRestUpsertModel request)
        {
            var updateRequest = _mapper.Map<TrackingUpdateRequest>(request);
            updateRequest.ModifiedUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            updateRequest.ModifiedDate = DateTime.Now;
            return Ok(await _service.Update(id,updateRequest));
        }
    }
}
