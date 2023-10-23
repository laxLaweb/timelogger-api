using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeLogger.Access;
using TimeLogger.Dto;

namespace TimeLogger.Services.Impl
{
    public class TimeRegisterService : ITimeRegisterService
    {
        private readonly ITimeRegisterAccess timeRegisterAccess;
        public TimeRegisterService(ITimeRegisterAccess timeRegisterAccess)
        {
            this.timeRegisterAccess = timeRegisterAccess;
        }

        public async Task<List<TimeRegisterDto>> ListTimeRegisterDto(int projectId)
        {
            var timeRegisters = await timeRegisterAccess.List(projectId);

            var timeRegisterDtos = new List<TimeRegisterDto>();
            foreach(var timeRegister in timeRegisters)
            {
                var timeRegisterDto = new TimeRegisterDto();
                timeRegisterDto.FillWithTimeRegister(timeRegister);
                timeRegisterDtos.Add(timeRegisterDto);
            }

            return timeRegisterDtos;
        }

        public async Task AddTimeOnProject(int projectId, TimeRegisterDto dto)
        {
            // Check if the date exists allready
            var timeRegister = await timeRegisterAccess.GetByProjectIdAndDate(projectId, dto.Date);

            if(timeRegister != null)
            {
                // Update existing row in the db with the added hours
                timeRegister.Hours += dto.Hours;
                await timeRegisterAccess.Save(timeRegister);
            }
            else
            {
                // Create new row in database
                await timeRegisterAccess.AddTimeOnProject(projectId, dto.Date, dto.Hours);
            }
            
        }
    }
}
