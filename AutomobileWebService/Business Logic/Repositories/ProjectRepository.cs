using AutomobileWebService.Business_Logic.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomobileWebService.Business_Logic.Models;
using AutomobileWebService.Business_Logic.Repositories.DAL;

namespace AutomobileWebService.Business_Logic.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private AutomobileContext _context { get; set; }

        public ProjectRepository(AutomobileContext context)
        {
            _context = context;
        }

        public async Task<Project> GetAsync(Guid id)
            => await Task.FromResult(_context.Projects.SingleOrDefault(x => x.Id == id));

        public async Task<Project> GetAsync(string projectName)
            => await Task.FromResult(_context.Projects.SingleOrDefault(x => x.ProjectName.ToLowerInvariant() == projectName.ToLowerInvariant()));

        public async Task<IEnumerable<Project>> BrowseAsync(string projectName = null)
        {
            var projects = _context.Projects.AsEnumerable();

            if (projectName != null)
            {
                projects = projects.Where(x => x.ProjectName.ToLowerInvariant().Contains(projectName.ToLowerInvariant()));
            }

            return await Task.FromResult(projects);
        }

        public async Task<IEnumerable<Project>> BrowseAsync(int horsepower)
        {
            var projects = _context.Projects.AsEnumerable();
            if (horsepower > 0)
            {
                projects = projects.Where(x => x.Horsepower == horsepower).AsEnumerable();
            }

            return await Task.FromResult(projects);
        }

        public Task CreateAsync(Project project)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
