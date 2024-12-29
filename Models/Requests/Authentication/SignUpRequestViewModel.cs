using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace VetTail.Models.Requests.Authentication;

public class SignUpRequestViewModel
{
    [Required(ErrorMessage = $"{nameof(UserName)} is required.")]
    [MinLength(3, ErrorMessage = $"{nameof(UserName)} must be at least 3 characters long.")]
    public required string UserName { get; set; }


    [EmailAddress]
    [Required(ErrorMessage = $"{nameof(Email)} is required.")]
    public required string Email { get; set; }


    [DataType(DataType.Password)]
    [Required(ErrorMessage = $"{nameof(Password)} is required.")]
    [MinLength(6, ErrorMessage = $"{nameof(Password)} must be at least 6 characters long.")]
    public required string Password { get; set; }


    [DataType(DataType.Password)]
    [Required(ErrorMessage = $"{nameof(ConfirmPassword)} is required.")]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    public required string ConfirmPassword { get; set; }

}
