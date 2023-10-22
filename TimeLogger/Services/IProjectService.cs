using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeLogger.Dto;

namespace TimeLogger.Services
{
    public interface IProjectService
    {
        public Task<List<ProjectDto>> ListProjectDto(string sortColumn);
    }
}
