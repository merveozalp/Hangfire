using AutoMapper;
using Hangfire;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Papara.Core.Dtos;
using Papara.Core.Entites;
using Papara.Core.Entity;
using Papara.Core.Enums;
using Papara.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papara.Infrastructure.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DbSet<User> _users;
        public UserRepository(ApplicationDbContext dbContext, Func<CacheTech, ICacheService> cacheService) :
            base(dbContext, cacheService)
        {
            _users = dbContext.Set<User>();
        }

       
    }
}
