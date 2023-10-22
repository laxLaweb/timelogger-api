using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeLogger.Entities;

namespace TimeLogger.Access.Impl
{
    public class TimeRegisterAccess : BaseAccess<TimeRegister>, ITimeRegisterAccess
    {
        // This class should comminicate with the database, but for saving time this will be mock data in memory instead
        private readonly List<TimeRegister> timeRegister;
        private int nextId = 1;
        public TimeRegisterAccess()
        {
            timeRegister = new List<TimeRegister>();

            timeRegister.Add(new TimeRegister()
            {
                Id = nextId,
                ProjectId = 1,
                Date = "2023-10-11",
                Hours = 5
            });
            nextId++;

            timeRegister.Add(new TimeRegister()
            {
                Id = nextId,
                ProjectId = 1,
                Date = "2023-10-10",
                Hours = 2
            });
            nextId++;

            timeRegister.Add(new TimeRegister()
            {
                Id = nextId,
                ProjectId = 1,
                Date = "2023-10-13",
                Hours = 3
            });
            nextId++;

            timeRegister.Add(new TimeRegister()
            {
                Id = nextId,
                ProjectId = 1,
                Date = "2023-10-12",
                Hours = 7
            });
            nextId++;

            timeRegister.Add(new TimeRegister()
            {
                Id = nextId,
                ProjectId = 2,
                Date = "2023-10-12",
                Hours = 6
            });
            nextId++;
        }

        public async Task AddTimeOnProject(int projectId, string date, float hours)
        {
            // Skip adding id, since its only used for db purpose
            timeRegister.Add(new TimeRegister()
            {
                Id = nextId,
                ProjectId = projectId,
                Date = date,
                Hours = hours
            });
            nextId++;
        }

        public async Task<TimeRegister> GetByProjectIdAndDate(int projectId, string date)
        {
            return timeRegister.Where(x => x.ProjectId == projectId && x.Date.Equals(date)).FirstOrDefault();
        }

        public async Task<List<TimeRegister>> List(int projectId)
        {
            return timeRegister.Where(x => x.ProjectId == projectId)
                .OrderBy(x => x.Date)
                .ToList();
        }
    }
}
