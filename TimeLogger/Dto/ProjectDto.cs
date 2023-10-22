using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeLogger.Entities;

namespace TimeLogger.Dto
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime Deadline { get; set; }

        public void FillWithProject(Project project)
        {
            Id = project.Id;
            Name = project.Name;
            Active = project.Active;
            Deadline = project.Deadline;
        }
    }
}
