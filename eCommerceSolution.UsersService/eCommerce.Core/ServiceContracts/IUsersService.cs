using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts;
/// <summary>
/// Contract for User Service that contains use cases for user management.
/// </summary>
internal interface IUsersService
{
    /// <summary>
    /// Method to handle user login use case and returns an AuthenticationResponse object that contains the status of the login
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);

    /// <summary>
    /// Method to handle user registration use case and returns an AuthenticationResponse object that contains the status of the registration
    /// </summary>
    /// <param name="registerRequest"></param>
    /// <returns></returns>

    Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
}
