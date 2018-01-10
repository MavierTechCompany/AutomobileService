using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomobileWebService.Business_Logic.Models;
using AutomobileWebService.Business_Logic.Repositories.DAL;
using AutomobileWebService.Business_Logic.Repositories.Interfaces;

namespace AutomobileWebService.Business_Logic.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AutomobileContext _context { get; set; }

        public UserRepository(AutomobileContext context)
        {
            _context = context;
        }

        public async Task<User> GetAsync(Guid id)
               => await Task.FromResult(_context.Users.SingleOrDefault(x => x.Id == id && x.Deleted == false));

        public async Task<User> GetAsync(string login)
            => await Task.FromResult(_context.Users.SingleOrDefault(x => x.Login.ToLowerInvariant() == login.ToLowerInvariant() && x.Deleted == false));

        public async Task<User> GetByEmailAsync(string email)
            => await Task.FromResult(_context.Users.SingleOrDefault(x => x.Email.ToLowerInvariant() == email.ToLowerInvariant() && x.Deleted == false));

        public async Task<IEnumerable<User>> BrowseAsync(string login = null)
        {
            var users = _context.Users.Where(x => x.Deleted == false).AsEnumerable();

            if (!string.IsNullOrWhiteSpace(login))
            {
                users = users.Where(x => x.Login.ToLowerInvariant().Contains(login.ToLowerInvariant()));
            }

            return await Task.FromResult(users);
        }

        public async Task CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            await Task.FromResult(_context.Users.Update(user));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            var deletedUser = User.Delete(user);
            await Task.FromResult(_context.Users.Update(deletedUser));
            await _context.SaveChangesAsync();
        }
    }
}