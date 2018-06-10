using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomobileWebService.Business_Logic.Commands.User;
using AutomobileWebService.Business_Logic.Models;
using AutomobileWebService.Business_Logic.Repositories.Extensions;
using AutomobileWebService.Business_Logic.Repositories.Interfaces;
using AutomobileWebService.Services.Interfaces;

namespace AutomobileWebService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetAsync(int id)
        {
            var user = await _userRepository.GetOrFailAsync(id);
            return user;
        }

        public async Task<User> GetAsync(string login)
        {
            var user = await _userRepository.GetOrFailAsync(login);
            return user;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailOrFailAsync(email);
            return user;
        }

        public async Task<IQueryable<User>> BrowseAsync(string login = null)
        {
            var users = await _userRepository.BrowseOrFailAsync(login);
            return users;
        }

        public async Task CreateAsync(CreateCommand command)
        {
            var user = new User(command.Login, command.Email, command.MobilePhone, command.Password);
            await _userRepository.CreateOrFailAsync(user);
        }
    }
}