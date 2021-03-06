﻿using AutomobileWebService.Business_Logic.Repositories.Interfaces;
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

        public async Task<Project> GetAsync(int id)
            => await Task.FromResult(_context.Projects.SingleOrDefault(x =>
            x.Id == id && x.Deleted == false));

        public async Task<Project> GetAsync(string projectName)
            => await Task.FromResult(_context.Projects.SingleOrDefault(x =>
            x.ProjectName.ToLowerInvariant() == projectName.ToLowerInvariant() &&
            x.Deleted == false));

        public async Task<IQueryable<Project>> BrowseAsync(string projectName = null)
        {
            var projects = _context.Projects.Where(x => x.Deleted == false).AsQueryable();

            if (!string.IsNullOrWhiteSpace(projectName))
            {
                projects = projects.Where(x => x.ProjectName.ToLowerInvariant().
                    Contains(projectName.ToLowerInvariant()));
            }

            return await Task.FromResult(projects);
        }

        public async Task<IQueryable<Project>> BrowseAsync(int horsepower)
        {
            var projects = _context.Projects.Where(x => x.Deleted == false).AsQueryable();
            if (horsepower > 0)
            {
                projects = projects.Where(x => x.Horsepower == horsepower);
            }

            return await Task.FromResult(projects);
        }

        public async Task CreateAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Project project)
        {
            await Task.FromResult(_context.Projects.Update(project));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Project project)
        {
            project.Delete();
            await Task.FromResult(_context.Projects.Update(project));
            await _context.SaveChangesAsync();  
        }
    }
}
