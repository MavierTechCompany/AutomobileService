using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomobileWebService.Business_Logic.Models;
using AutomobileWebService.Business_Logic.Repositories.DAL;
using AutomobileWebService.Business_Logic.Repositories.Interfaces;

namespace AutomobileWebService.Business_Logic.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private AutomobileContext _context { get; set; }

        public CommentRepository(AutomobileContext context)
        {
            _context = context;
        }

        public async Task<Comment> GetAsync(int id)
               => await Task.FromResult(_context.Comments.SingleOrDefault(x => x.Id == id && x.Deleted == false));

        public async Task<IEnumerable<Comment>> GetAllByProjectAsync(int projectId)
               => await Task.FromResult(_context.Comments.Where(x => x.ProjectId == projectId && x.Deleted == false).AsEnumerable());

        public async Task<IEnumerable<Comment>> GetAllByCommenterAsync(int commenterid)
               => await Task.FromResult(_context.Comments.Where(x => x.CommenterId == commenterid && x.Deleted == false).AsEnumerable());

        public async Task CreateAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Comment comment)
        {
            await Task.FromResult(_context.Comments.Update(comment));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Comment comment)
        {
            comment.Delete();
            await Task.FromResult(_context.Comments.Update(comment));
            await _context.SaveChangesAsync();
        }
    }
}