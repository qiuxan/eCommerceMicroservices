namespace eCommerce.Core.DTO;

public record AuthenticationResponse(
    Guid UserId,
    string? Email,
    string? PersionName,
    string? Gender,
    string? Token,
    bool Success
)
{

    //Parameterless constructor 
    public AuthenticationResponse():this(default,default,default,default,default,default)
    {
        
    }
}