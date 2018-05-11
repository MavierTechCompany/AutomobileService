using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomobileWebService.Business_Logic.Commands.User;
using AutomobileWebService.Business_Logic.Models;

namespace AutomobileWebService.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetAsync(int id);
        Task<User> GetAsync(string login);
        Task<User> GetByEmailAsync(string email);
        Task<IQueryable<User>> BrowseAsync(string login = null);
        Task CreateAsync(CreateCommand command);
        //Task UpdateAsync(User user);
        //Task DeleteAsync(User user);
    }
}