using Meetups.Domain;
using Meetups.Domain.Entities;
using Meetups.Models;
using Meetups.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Meetups.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class MeetupController : ControllerBase
    {
        private readonly DataManager dataManager;

        public MeetupController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetMeetupDto>>>> Get()
        {
            return Ok(await dataManager.Meetups.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetMeetupDto>>> GetSingle(int id)
        {
            return Ok(await dataManager.Meetups.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetMeetupDto>>>> AddMeetup(AddMeetupDto newMeetup)
        {
            return Ok(await dataManager.Meetups.Add(newMeetup));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetMeetupDto>>> UpdateMeetup(UpdateMeetupDto updatedMeetup)
        {
            ServiceResponse<GetMeetupDto> response = await dataManager.Meetups.Update(updatedMeetup);
            if (response.Data == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetMeetupDto>>>> DeleteMeetup(int id)
        {
            ServiceResponse<List<GetMeetupDto>> response = await dataManager.Meetups.Delete(id);
            if (response.Data == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

    }
}
