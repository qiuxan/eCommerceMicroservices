
using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;

/// <summary>
/// It will be internal class because it is not exposed to the outer world
/// 
/// </summary>
internal class UsersRepository : IUsersRepository
{
    private readonly DapperDbContext _dbContext;

    public UsersRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        //dummy implementation

        user.UserId = Guid.NewGuid();

        //SQL query to insert the user into the database "Users" table

        string query = "INSERT INTO public.\"Users\"(\"UserID\",\"Email\",\"PersonName\",\"Gender\",\"Password\") VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";

        int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query,user);

        if (rowCountAffected == 0)
        {
            return null;
        }

        return user;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {

        //SQL query to retrieve the user from the database "Users" table

        string query = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";
        var parameters = new { Email = email, Password = password };
        ApplicationUser? user = await
        _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

        return user; // firstOrDefault will return null if no user found so no need to check for null
    }
}
