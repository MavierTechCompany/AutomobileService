using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using AutomobileWebService.Business_Logic.Models;
using AutomobileWebService.Business_Logic.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileWebService.Business_Logic.Repositories.Extensions
{
    public static class ProjectExtensions
    {
		public static async Task<Project> GetOrFailAsync(this IProjectRepository repository, int id )
		{
			var project = await repository.GetAsync(id);

			if (project == null)
			{
				throw new NullResponseException($"There is no project with id: {id}.");
			}

			return await Task.FromResult(project);
		}

		public static async Task<Project> GetOrFailAsync(this IProjectRepository repository, string projectName)
		{
			var project = await repository.GetAsync(projectName);

			if (project == null)
			{
				throw new NullResponseException($"There is no project with name: {projectName}");
			}

			return await Task.FromResult(project);
		}

		public static async Task<IEnumerable<Project>> BrowseOrFailAsync(this IProjectRepository repository, string projectName = null)
		{
			var projects = await repository.BrowseAsync(projectName);

			if (projects == null)
			{
				throw new NullResponseException($"There isn't any project with name: {projectName}.");
			}

			return await Task.FromResult(projects);
		}

		public static async Task<IEnumerable<Project>> BrowseOrFailAsync(this IProjectRepository repository, int horsepower)
		{
			var projects = await repository.BrowseAsync(horsepower);

			if (projects == null)
			{
				throw new NullResponseException($"There isn't any project with horsepower: {horsepower}");
			}

			return await Task.FromResult(projects);
		}

		public static async Task CreateOrFailAsync(this IProjectRepository repository,
			Project _project)
		{
			var project = await repository.GetAsync(_project.ProjectName);

			if (project != null)
			{
				throw new ForbiddenValueException($"There is already a project with name: {_project.ProjectName}.");
			}

			await repository.CreateAsync(_project);
		}

		public static async Task UpdateOrFailAsync(this IProjectRepository repository,
			Project _project)
		{
			var project = await repository.GetAsync(_project.Id);

			if (project == null)
			{
				throw new NullResponseException($"There is no project with id: {_project.Id}");
			}

			await repository.UpdateAsync(_project);
		}

		public static async Task DeleteOrFailAsync(this IProjectRepository repository,
			int id)
		{
			var project = await repository.GetAsync(id);

			if (project == null)
			{
				throw new NullResponseException($"There is no project with id: {id}.");
			}

			await repository.DeleteAsync(project);
		}
	}
}
