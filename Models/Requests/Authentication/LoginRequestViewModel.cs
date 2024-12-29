using System.ComponentModel.DataAnnotations;

namespace VetTail.Models.Requests.Authentication;

public class LoginRequestViewModel
{
    [Required(ErrorMessage = $"{nameof(Username)} is required.")]
    [MinLength(3, ErrorMessage =$"{nameof(Username)} must be at least 3 characters long.")]
    public required string Username { get; set; }

    [Required(ErrorMessage = $"{nameof(Password)} is required.")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = $"{nameof(Password)} must be at least 6 characters long.")]
    public required string Password { get; set; }

    public bool RememberMe { get; set; }
}
