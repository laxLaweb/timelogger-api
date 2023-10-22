using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeLogger.Entities;

namespace TimeLogger.Access
{
    public interface IProjectAccess : IBaseAccess<Project>
    {
        public Task<List<Project>> List(string sortColumn);
    }
}
