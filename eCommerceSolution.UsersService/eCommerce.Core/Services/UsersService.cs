
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.RepositoryContracts;

namespace eCommerce.Core.Services;
public class UsersService: IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser? user = await
            _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        if (user == null)
        {
            return null;
        }

        return new AuthenticationResponse(
            user.UserId,
            user.Email,
            user.PersionName,
            user.Password,
            "token",
            true
        );
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        //Create a new user from the request
        ApplicationUser user = new ApplicationUser()
        {
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            PersionName = registerRequest.PersionName,
            Gender = registerRequest.Gender.ToString(),

        };

        ApplicationUser?  registerUser = await _usersRepository.AddUser(user);

        if (registerUser == null)
        {
            return null;
        }

        return new AuthenticationResponse(
            registerUser.UserId,
            registerUser.Email,
            registerUser.PersionName,
            registerUser.Password,
            "token",
            true
            );

    }
}
