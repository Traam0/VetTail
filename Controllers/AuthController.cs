using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using VetTail.Application.Common.Interfaces;
using VetTail.Domain.Common.Exceptions;
using VetTail.Domain.Entities;
using VetTail.Models.Requests.Authentication;

namespace VetTail.Controllers;

public class AuthController : Controller
{

    private readonly ILogger<AuthController> logger;
    private readonly IAuthenticationService authService;
    private readonly SignInManager<User> signInManager;

    public AuthController(IAuthenticationService authService, SignInManager<User> signInManager, ILogger<AuthController> logger)
    {
        this.logger = logger;
        this.authService = authService;
        this.signInManager = signInManager;
    }

    public ActionResult Login()
    {
        if (this.User.Identity?.IsAuthenticated is true)
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Login(LoginRequestViewModel credentials, CancellationToken cancellationToken)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(credentials);
            }

            User user = await this.authService.LoginUser(credentials.Username, credentials.Password, cancellationToken);
            await this.signInManager.SignInAsync(user, credentials.RememberMe);
            return RedirectToAction("Index", "Home");
        }
        catch (EntityNullReferenceException<User> exception)
        {
            this.logger.LogWarning("Failed Authentication Attempt: {Message}\n\t{@Crdentials}", exception.Message, credentials);
            ModelState.AddModelError(string.Empty, "Invalid Username");
            return View(credentials);
        }
        catch (InvalidCredentialException exception)
        {
            this.logger.LogWarning("Failed Authentication Attempt: {Message}\n\t{@Credentials}", exception.Message, credentials);
            ViewData.ModelState.AddModelError(string.Empty, exception.Message);
            return View(credentials);
        }
    }


    public ActionResult SignUp()
    {
        if (this.User.Identity?.IsAuthenticated is true)
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public  async Task<ActionResult> SignUp(SignUpRequestViewModel credentials, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid) return View(credentials);
        //IdentityResult result = await this.authenticationService.RegisterUser(credentials, cancellationToken);

        //if (result.Succeeded) { 
        //    return RedirectToAction("Login");
        //}

        //this.ViewBag.Error  = result.Errors.LastOrDefault()?.Description;

        return View(credentials);

    }

    public async Task<IActionResult> Logout()
    {
        if (this.User.Identity?.IsAuthenticated is false)
        {
            return RedirectToAction("Index", "Home");
        }
        await this.signInManager.SignOutAsync();
        return RedirectToAction(nameof(Login));
    }
}
