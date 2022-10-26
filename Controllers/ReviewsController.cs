using ConcertGrail.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ConcertGrail.Controllers;       

public class ReviewsController : Controller
{
    private MyContext Database; // Instantiate database 

    public ReviewsController(MyContext database)
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

    [HttpGet("/reviews/new")] // Route: New Review Form
    public IActionResult NewReview()
    {
        if(!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }

        return View("NewReview");
    }

    [HttpPost("/reviews/create")] // Route: Create Review 
    public IActionResult Create(Review newReview)
    {
        // Validate form data
        if(!ModelState.IsValid)
        {
            return NewReview();
        }

        newReview.UserId = (int)userId; // Attach user Id to 
        Database.Add(newReview); // Add to db
        Database.SaveChanges(); // Save changes
        return RedirectToAction("Share", "Users"); // Redirect to Share page
    }
}