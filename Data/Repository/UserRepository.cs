using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.Context;
using Infrastructure.Options.Context;
using Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Data.Repository
{
    public class UserRepository : RepositoryBase<User> , IUserRepository
    {
        public UserRepository(SuperDigitalDbContext dbContext) : base(dbContext)
        {
        }

        public User Authenticate(string email, string password)
        {
            password = Encryption.GetSha1Hash(password);
            return DbSet.FirstOrDefault(user => user.Email == email && user.Password == password && user.Active);
        }

        public User GetByEmail(string email)
        {
            return DbSet.FirstOrDefault(user => user.Email == email && user.Active);
        }

        public new IEnumerable<User> GetAll()
        {
            return DbSet.Include(x => x.UserCodes).AsNoTracking();
        }
    }
}
