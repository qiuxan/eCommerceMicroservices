
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;

namespace eCommerce.Infrastructure.Repositories;

/// <summary>
/// It will be internal class because it is not exposed to the outer world
/// 
/// </summary>
internal class UsersRepository : IUserRepository
{
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        //dummy implementation

        user.UserId = Guid.NewGuid();
        return user;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        return new ApplicationUser
        {
            UserId = Guid.NewGuid(),
            Email = email,
            Password = password,
            PersionName = "John Doe",
            Gender = GenderOptions.Male.ToString()
        };
    }
}
