using Data.Extensions;
using Domain.Entities;
using Infrastructure.Data.Mappings;
using Infrastructure.Options.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace Infrastructure.Data.Context
{
    public class SuperDigitalDbContext : DbContext
    {
        public SuperDigitalDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> User {get;set;}
        public DbSet<CheckingAccount> CheckingAccount { get;set;}
        public DbSet<Transaction> Transaction { get;set;}
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.AddConfiguration(new UserMap());
            builder.AddConfiguration(new TransactionMap());

            base.OnModelCreating(builder);
        }
    }
}
