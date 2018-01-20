using AutoMapper;
using AutomobileWebService.Business_Logic.Infrastructure.DTO;
using AutomobileWebService.Business_Logic.Repositories.Interfaces;
using AutomobileWebService.Business_Logic.Repositories.Extensions;
using AutomobileWebService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileWebService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetAsync(Guid id)
        {
            var user = await _userRepository.GetOrFailAsync(id);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetAsync(string login)
        {
            var user = await _userRepository.GetOrFailAsync(login);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailOrFailAsync(email);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> BrowseAsync(string login = null)
        {
            var users = await _userRepository.BrowseOrFailAsync(login);

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task CreateAsync(Guid id, string login, string email, string mobilePhone, string password)
        {

        }
    }
}
