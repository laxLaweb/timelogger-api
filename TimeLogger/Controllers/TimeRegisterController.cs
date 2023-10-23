using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeLogger.Dto;
using TimeLogger.Services;

namespace TimeLogger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeRegisterController : ControllerBase
    {
        private readonly ITimeRegisterService timeRegisterService;
        public TimeRegisterController(ITimeRegisterService timeRegisterService)
        {
            this.timeRegisterService = timeRegisterService;
        }

        /**
         * This will list all the time register on a single project
         */
        [HttpGet("list/{projectId}")]
        public async Task<ActionResult<List<TimeRegisterDto>>> ListTimeRegisterOnProject(
            [FromRoute] int projectId
            )
        {
            var timeRegisterDtos = await timeRegisterService.ListTimeRegisterDto(projectId);
            return Ok(timeRegisterDtos);
        }

        /**
         * This method is used to add time on a project
         */
        [HttpPost("{projectId}")]
        public async Task<ActionResult> SaveTimeRegister(
            [FromRoute] int projectId, 
            [FromBody] TimeRegisterDto dto
            )
        {
            if(dto.Hours <= 0)
            {
                return BadRequest("Hours could not be negative");
            }
            if((dto.Hours * 100) % 50 == 0)
            {
                return BadRequest("Hours can only have 0 or 5 after comma");
            }

            if(dto.Hours > 24)
            {
                return BadRequest("Hours could not be above 24");
            }

            await timeRegisterService.AddTimeOnProject(projectId, dto);
            return StatusCode(201);
        }
    }
}
