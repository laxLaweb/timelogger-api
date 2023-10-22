using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeLogger.Entities;

namespace TimeLogger.Access
{
    public interface ITimeRegisterAccess : IBaseAccess<TimeRegister>
    {
        public Task AddTimeOnProject(int projectId, string date, float hours);
        public Task<List<TimeRegister>> List(int projectId);
        public Task<TimeRegister> GetByProjectIdAndDate(int projectId, string date);
    }
}
