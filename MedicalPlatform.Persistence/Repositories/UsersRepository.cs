using AutoMapper;
using MedicalPlatform.Core.Interfaces.Repositories;
using MedicalPlatform.Core.Models;
using MedicalPlatform.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlatform.Persistence.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly MedicalDbContext _context;
        private readonly IMapper _mapper;

        public UsersRepository(MedicalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(User user)
        {
            var userEntity = new UserEntity()
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByUserName(string userName)
        {
            var userEntity = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.UserName == userName) ?? throw new Exception();

            return _mapper.Map<User>(userEntity);
        }
    }
}
