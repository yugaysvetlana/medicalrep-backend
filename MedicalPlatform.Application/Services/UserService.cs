﻿using MedicalPlatform.Application.Interfaces.Auth;
using MedicalPlatform.Core.Interfaces.Repositories;
using MedicalPlatform.Core.Interfaces.Services;
using MedicalPlatform.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlatform.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UserService(
            IUsersRepository usersRepository, 
            IPasswordHasher passwordHasher,
            IJwtProvider jwtProvider
            )
        {
            _usersRepository = usersRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task Register(string userName, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var user = User.Create(
                Guid.NewGuid(),
                userName,
                hashedPassword
                );

            await _usersRepository.Add(user);
        }

        public async Task<string> Login(string userName, string password)
        {
            var user = await _usersRepository.GetByUserName(userName);
            var result = _passwordHasher.Verify(password, user.PasswordHash);
            if (result == false)
            {
                throw new Exception("Failed to login");
            }

            var token = _jwtProvider.Generate(user);
            return token;
        }
    }
}
