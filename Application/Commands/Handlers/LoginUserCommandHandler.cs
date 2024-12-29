using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VetTail.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Authentication;
using VetTail.Domain.Common.Exceptions;
using VetTail.Application.Commands.Authentication;

namespace VetTail.Application.Commands.Handlers;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, User>
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;

    public LoginUserCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    public async Task<User> Handle(LoginUserCommand request, CancellationToken cancellationToken = default)
    {
        User user = await this.userManager.FindByNameAsync(request.Username) ?? throw new EntityNullReferenceException<User>(request.Username, nameof(request.Username));
        SignInResult attempt = await this.signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if(!attempt.Succeeded) throw new InvalidCredentialException("Invalid Credentials");
        return user;
    }
}
