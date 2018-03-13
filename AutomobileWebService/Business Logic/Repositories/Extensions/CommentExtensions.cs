using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using AutomobileWebService.Business_Logic.Models;
using AutomobileWebService.Business_Logic.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileWebService.Business_Logic.Repositories.Extensions
{
	public static class CommentExtensions
	{
		public static async Task<Comment> GetOrFailAsync(this ICommentRepository repository, int id)
		{
			var comment = await repository.GetAsync(id);

			if (comment == null)
			{
				throw new ForbiddenValueException($"There is no comment with id: {id}.");
			}

			return await Task.FromResult(comment);
		}

		public static async Task<IEnumerable<Comment>> GeAllByProjectOrFailAsync(this ICommentRepository repository, int projectId)
		{
			var comment = await repository.GetAllByProjectAsync(projectId);

			if (comment == null)
			{
				throw new ForbiddenValueException($"There is no comment with project id: {projectId}.");
			}

			return await Task.FromResult(comment);
		}

		public static async Task<IEnumerable<Comment>> GetAllByCommenterOrFailAsync(this ICommentRepository repository, int commenterId)
		{
			var comment = await repository.GetAllByCommenterAsync(commenterId);

			if (comment == null)
			{
				throw new NullResponseException($"There is no comment with commenter id: {commenterId}.");
			}

			return await Task.FromResult(comment);
		}

		public static async Task DeleteOrFailAsync(this ICommentRepository repository, int id)
		{
			var comment = await repository.GetAsync(id);

			if (comment == null)
			{
				throw new NullResponseException($"There is no comment with id: {id}.");
			}

			await repository.DeleteAsync(comment);
		}
	}
}	









