using Azure.Core;
using Microsoft.AspNetCore.Identity;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using VetTail.Application.Common.Interfaces;
using VetTail.Domain.Common.Exceptions;
using VetTail.Domain.Entities;

namespace VetTail.Application.Services;

public class AuthenticationService : IAuthenticationServices
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;

    public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    public async Task<User> LoginUser(string username, string password, CancellationToken cancellationToken = default)
    {
        User user = await this.userManager.FindByNameAsync(username) ?? throw new EntityNullReferenceException<User>(username, nameof(username));
        SignInResult attempt = await this.signInManager.CheckPasswordSignInAsync(user, password, false);
        if (!attempt.Succeeded) throw new InvalidCredentialException("Invalid Credentials");
        return user;
    }
}
