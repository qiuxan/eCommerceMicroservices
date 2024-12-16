using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts;
/// <summary>
/// Contract to be implemented by the User Repository that contains the data access logic of user data store
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Method to add user to the data store and return the added user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<ApplicationUser?>AddUser(ApplicationUser user);

    /// <summary>
    /// Method to retrieve existing user by email and password
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<ApplicationUser?>GetUserByEmailAndPassword(string? email, string? password);


}
