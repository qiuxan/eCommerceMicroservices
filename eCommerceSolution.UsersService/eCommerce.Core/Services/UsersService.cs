
using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.RepositoryContracts;

namespace eCommerce.Core.Services;
public class UsersService: IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public UsersService(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;

    }

    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser? user = await
            _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        if (user == null)
        {
            return null;
        }

        // return new AuthenticationResponse(
        //     user.UserId,
        //     user.Email,
        //     user.PersonName,
        //     user.Password,
        //     "token",
        //     true
        // );

        return _mapper.Map<AuthenticationResponse>(user) with{Success = true, Token = "token"};
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        //Create a new user from the request
        ApplicationUser user = new ApplicationUser()
        {
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            PersonName = registerRequest.PersonName,
            Gender = registerRequest.Gender.ToString(),

        };

        ApplicationUser?  registerUser = await _usersRepository.AddUser(user);

        if (registerUser == null)
        {
            return null;
        }

        // return new AuthenticationResponse(
        //     registerUser.UserId,
        //     registerUser.Email,
        //     registerUser.PersonName,
        //     registerUser.Password,
        //     "token",
        //     true
        //     );
        return _mapper.Map<AuthenticationResponse>(registerUser) with { Success = true, Token = "token" };

    }
}
