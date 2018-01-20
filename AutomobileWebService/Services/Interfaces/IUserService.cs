using AutomobileWebService.Business_Logic.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileWebService.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetAsync(Guid id);
        Task<UserDto> GetAsync(string login);
        Task<UserDto> GetByEmailAsync(string email);
        Task<IEnumerable<UserDto>> BrowseAsync(string login = null);
        Task CreateAsync(Guid id, string login, string email, string mobilePhone, string password);
        //Task UpdateAsync(User user);
        //Task DeleteAsync(User user);
    }
}
