﻿using AutomobileWebService.Business_Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AutomobileWebService.Business_Logic.Repositories.Interfaces
{
    public interface ICommentRepository
    {
		Task<Comment> GetAsync(Guid id);
		Task<IEnumerable<Comment>> GetAllByProjectAsync(Guid projectId);
		Task<IEnumerable<Comment>> GetAllByCommenterAsync(Guid commenterId);
		Task CreateAsync(Comment comment);
		Task UpdateAsync(Comment comment);
		Task DeleteAsync(Comment comment);	
	}
}
