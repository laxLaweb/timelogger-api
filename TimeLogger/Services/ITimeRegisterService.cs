using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeLogger.Dto;

namespace TimeLogger.Services
{
    public interface ITimeRegisterService
    {
        public Task<List<TimeRegisterDto>> ListTimeRegisterDto(int projectId);
        public Task AddTimeOnProject(int projectId, TimeRegisterDto dto);
    }
}
