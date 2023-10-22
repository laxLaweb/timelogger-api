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
    public class ProjectController : ControllerBase
    {
        private IProjectService projectService;
        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> ListProjects([FromQuery] string sortColumn = "name")
        {
            var projects = await projectService.ListProjectDto(sortColumn);
            return Ok(projects);
        }
    }
}
