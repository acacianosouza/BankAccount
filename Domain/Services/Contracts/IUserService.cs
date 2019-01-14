using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Validation;

namespace Domain.Services.Contracts
{
    public interface IUserService : IServiceBase<User>
    {
        User Authenticate(string email, string password);
        User GetByEmail(string email);
        new ValidationResult Add(User user);
    }
}
