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
        Task<IEnumerable<Project>> BrowseAsync(string projectName = null);
        Task<IEnumerable<Project>> BrowseAsync(int horsepower);
        Task CreateAsync(Project project);
        Task UpdateAsync(Project project);
    }
}
