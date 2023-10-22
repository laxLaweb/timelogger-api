using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeLogger.Access;
using TimeLogger.Dto;

namespace TimeLogger.Services.Impl
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectAccess projectAccess;
        public ProjectService(IProjectAccess projectAccess)
        {
            this.projectAccess = projectAccess;
        }

        public async Task<List<ProjectDto>> ListProjectDto(string sortColumn)
        {
            var projects = await projectAccess.List(sortColumn);

            var projectsDto = new List<ProjectDto>();

            foreach(var project in projects)
            {
                var projectDto = new ProjectDto();
                projectDto.FillWithProject(project);
                projectsDto.Add(projectDto);
            }

            return projectsDto;
        }
    }
}

