using ConcertGrail.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ConcertGrail.Controllers;        

public class ListingsController : Controller
{
    private MyContext Database; // Instantiate database 

    public ListingsController(MyContext database)
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

    [HttpGet("/listings/new")] // Route: New Listing Form
    public IActionResult NewListing()
    {
        if(!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }
        return View("NewListing");
    }

    [HttpPost("/listings/create")] // Route: Create Listing 
    public IActionResult Create(Listing newListing)
    {
        if(!ModelState.IsValid) // Validate form data
        {
            return NewListing();
        }

        newListing.UserId = (int)userId; // Assign user Id 
        Database.Add(newListing); // Add to db
        Database.SaveChanges(); // Save changes
        return RedirectToAction("Share", "Users"); // Redirect to Share page
    }
}