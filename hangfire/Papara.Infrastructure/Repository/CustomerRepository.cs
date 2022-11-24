
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Papara.Core.Entity;
using Papara.Core.Enums;
using Papara.Core.Interfaces;
using System;

namespace Infrastructure.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly DbSet<Customer> _customer;

        public CustomerRepository(ApplicationDbContext dbContext, Func<CacheTech, ICacheService> cacheService) : base(dbContext, cacheService)
        {
            _customer = dbContext.Set<Customer>();
        }
    }
}
