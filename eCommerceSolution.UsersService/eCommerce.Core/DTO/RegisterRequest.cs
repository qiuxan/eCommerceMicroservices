

namespace eCommerce.Core.DTO;

public record RegisterRequest(
    string? Email,
    string? Password,
    string? PersionName,
    GenderOptions Gender
);
