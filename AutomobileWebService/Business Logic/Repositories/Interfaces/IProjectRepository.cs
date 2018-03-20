using AutomobileWebService.Business_Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileWebService.Business_Logic.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project> GetAsync(int id);
        Task<Project> GetAsync(string projectName);
        Task<IQueryable<Project>> BrowseAsync(string projectName = null);
        Task<IQueryable<Project>> BrowseAsync(int horsepower);
        Task CreateAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteAsync(Project project);
    }
}
