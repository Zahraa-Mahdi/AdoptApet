using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AdoptApet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace AdoptApet.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<AppUser> userManager;
    private readonly SignInManager<AppUser> signInManager;
    private IPasswordHasher<AppUser> passwordHasher;


    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
        IPasswordHasher<AppUser> passwordHasher)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.passwordHasher = passwordHasher;
    }

    //l get mn l database lal views l get bs view bt2ra l url w btaardu ka view
    //GET /account/register
    [AllowAnonymous]
    public IActionResult Register() => View();

    //POST /account/register
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(User user)
    {
        if (ModelState.IsValid)
        {
            AppUser appUser = new AppUser
            {
                UserName = user.UserName,
                Email = user.Email
            };

            IdentityResult result = await userManager.CreateAsync(appUser, user.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }


        }
        return View(user);
    }
    //GET /account/register
    [AllowAnonymous]
    public IActionResult login(string returnUrl)
    {
        Login login = new Login
        {
            ReturnUrl = returnUrl
        };
        return View(login);
    }


    //POST /account/Login
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(Login login)
    {
        if (ModelState.IsValid)
        {
            AppUser appUser = await userManager.FindByEmailAsync(login.Email);
            if (appUser != null)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync
                    (appUser, login.Password, false, false);
                if (result.Succeeded)
                {
                    return Redirect(login.ReturnUrl ?? "/");
                }

            }

            ModelState.AddModelError("", "Login failed, wrong credentials.");

        }
        return View(login);
    }

    //GET /account/Logout
    [AllowAnonymous]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return Redirect("/");
    }

    //GET /account/edit
    [AllowAnonymous]
    public async Task<IActionResult> Edit()
    {
        AppUser appUser = await userManager.FindByNameAsync(User.Identity.Name);
        UserEdit user = new UserEdit(appUser);

        return View(user);
    }

    //POST /account/edit
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UserEdit user)
    {
        AppUser appUser = await userManager.FindByNameAsync(User.Identity.Name);


        if (ModelState.IsValid)
        {
            appUser.Email = user.Email;

            if (user.Password != null)
            {
                appUser.PasswordHash = passwordHasher.HashPassword(appUser, user.Password);
            }

            IdentityResult result = await userManager.UpdateAsync(appUser);
            if (result.Succeeded)
                TempData["Success"] = "Your information has been edited!";

        }
        return View();

    }
}

