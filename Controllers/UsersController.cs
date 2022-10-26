using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ConcertGrail.Models;
namespace ConcertGrail.Controllers;     

public class UsersController : Controller
{
    private MyContext Database; // Instantiate database 

    public UsersController(MyContext database)
    {
        Database = database;
    }

    private int? userId // Checks if user logged in
    {
        get
        {
            return HttpContext.Session.GetInt32("UserId");
        }
    }

    private bool loggedIn
    {
        get
        {
            return userId != null;
        }
    }

    [HttpGet("/")] // Route: Login/Register 
    public IActionResult Index()
    {
        if (loggedIn) // If user logged in already, redirect to dashboard
        {
            return RedirectToAction("Dashboard");
        }
        return View("Index");
    }

    [HttpPost("/register")] // Route: Register User
    public IActionResult Register(User newUser)
    {
        if (!ModelState.IsValid) // Invalid form data
        {
            return Index();
        }
        
        if (ModelState.IsValid) // Valid form data
        {
            if (Database.Users.Any(u => u.Email == newUser.Email)) // Check if email is unique
            {
                ModelState.AddModelError("Email", "Email already registered.");
            }
        }

        PasswordHasher<User> hashedPW = new PasswordHasher<User>(); // Hash password
        newUser.Password = hashedPW.HashPassword(newUser, newUser.Password); // Updated newUser.Password

        Database.Add(newUser); // Add to DB
        Database.SaveChanges(); // Save Changes

        HttpContext.Session.SetInt32("UserId", newUser.UserId); // Initialize User ID session key

        return RedirectToAction("Dashboard");
    }

    [HttpPost("/login")] // Route: Login User
    public IActionResult Login(LoginUser loginUser)
    {
        if(!ModelState.IsValid) // Invalid form data
        {
            return Index();
        }
        User? dbUser = Database.Users.FirstOrDefault(u => u.Email == loginUser.LoginEmail); // Query db for user using email
        if(dbUser == null) // Check if user was found in db
        {
            ModelState.AddModelError("LoginEmail", "not found");
            return Index();
        }

        PasswordHasher<LoginUser> hashedPW = new PasswordHasher<LoginUser>(); // Hash password
        PasswordVerificationResult pwCompareResult = hashedPW.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);

        if(pwCompareResult == 0) // Compare hashed passwords
        {
            ModelState.AddModelError("LoginPassword", "not found");
            return Index();
        }

        HttpContext.Session.SetInt32("UserId", dbUser.UserId); // Initialize User ID session key

        return RedirectToAction("Dashboard");
    }

    [HttpGet("/logout")] // Route: Logout User
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [HttpGet("/dashboard")] // Route: Dashboard
    public IActionResult Dashboard()
    {
        if(!loggedIn) // Check if user logged in
        {
            return Index();
        }
        // TODO Add any necessary logic
        ViewBag.loggedUser = Database.Users.FirstOrDefault(u => u.UserId == userId);
        return View("Dashboard");
    }

    [HttpGet("/share")] // Route: Share page
    public IActionResult Share()
    {
        if(!loggedIn) // Check if user logged in
        {
            return Index();
        }
        ShareViewModel shareModel = new ShareViewModel();
        shareModel.Posts = Database.Posts.ToList(); // Get all posts from db
        shareModel.Reviews = Database.Reviews.ToList(); // Get all reviews from db
        shareModel.Listings = Database.Listings.ToList(); // Get all listings from db
        return View("Share", shareModel);
    }

    // TODO Route: Connect page
    [HttpGet("/connect")]
    public IActionResult Connect()
    {
        if(!loggedIn) // Check if user logged in
        {
            return Index();
        }
        // TODO: add name of connect cshtml file
        return View("");
    }
    
    // TODO Route: User Profile page
    [HttpGet("/profile")]
    public IActionResult Profile()
    {
        if(!loggedIn) // Check if user logged in
        {
            return Index();
        }
        // TODO: add name of profile cshtml file
        return View("");
    }
}