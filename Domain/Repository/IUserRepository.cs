using System.Collections.Generic;
using Domain.Interfaces.Repositories;
using Domain.Entities;
using Domain.Repository;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User Authenticate(string email, string password);
        User GetByEmail(string email);
    }
}
