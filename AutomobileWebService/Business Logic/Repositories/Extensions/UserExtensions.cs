﻿using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using AutomobileWebService.Business_Logic.Models;
using AutomobileWebService.Business_Logic.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileWebService.Business_Logic.Repositories.Extensions
{
    public static class UserExtensions
    {
        public static async Task<User> GetOrFailAsync(this IUserRepository repository, int id)
        {
            var user = await repository.GetAsync(id);

            if (user == null)
            {
                throw new ForbiddenValueException($"There is no user with id: {id}.");
            }

            return await Task.FromResult(user);
        }

        public static async Task<User> GetOrFailAsync(this IUserRepository repository, string login)
        {
            var user = await repository.GetAsync(login);

            if (user == null)
            {
                throw new ForbiddenValueException($"There is no user with login: {login}.");
            }

            return await Task.FromResult(user);
        }

        public static async Task<User> GetByEmailOrFailAsync(this IUserRepository repository, string email)
        {
            var user = await repository.GetByEmailAsync(email);

            if (user == null)
            {
                throw new ForbiddenValueException($"There is no user with email: {email}.");
            }

            return await Task.FromResult(user);
        }

        public static async Task<IEnumerable<User>> BrowseOrFailAsync(this IUserRepository repository, string login = null)
        {
            var users = await repository.BrowseAsync(login);

            if (users == null)
            {
                throw new ForbiddenValueException($"There isn't any user with login: {login}.");
            }

            return await Task.FromResult(users);
        }
    }
}
