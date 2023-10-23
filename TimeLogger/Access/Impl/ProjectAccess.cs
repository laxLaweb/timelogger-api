using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeLogger.Entities;

namespace TimeLogger.Access.Impl
{
    public class ProjectAccess : BaseAccess<Project>, IProjectAccess
    {
        // This class should comminicate with the database, but for saving time this will be mock data in memory instead
        private readonly List<Project> projects;
        public ProjectAccess()
        {
            projects = new List<Project>();

            projects.Add(new Project()
            {
                Id = 1,
                Name = "Project A",
                Active = true,
                Deadline = new DateTime(2023, 10, 25, 12, 0, 0)
            });

            projects.Add(new Project()
            {
                Id = 2,
                Name = "Project B",
                Active = true,
                Deadline = new DateTime(2023, 9, 5, 10, 0, 0)
            });

            projects.Add(new Project()
            {
                Id = 3,
                Name = "Project C",
                Active = true,
                Deadline = new DateTime(2023, 11, 12, 16, 0, 0)
            });

            projects.Add(new Project()
            {
                Id = 4,
                Name = "Project D",
                Active = false,
                Deadline = new DateTime(2023, 1, 2, 10, 30, 0)
            });
        }

        public async Task<List<Project>> List(string sortColumn)
        {
            // Since im not using and actual db I need so sort by code

            switch (sortColumn)
            {
                case "deadline":
                    return SortByDeadline();
                case "name":
                    // fallthrough
                default:
                    return SortByName();
            }
        }

        private List<Project> SortByName()
        {
            return projects.OrderBy(o => o.Name).ToList();
        }

        private List<Project> SortByDeadline()
        {
            return projects.OrderBy(o => o.Deadline).ToList();
        }
    }
}
