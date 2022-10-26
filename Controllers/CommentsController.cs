using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ConcertGrail.Controllers;       

public class CommentsController : Controller
{
    // TODO Route: Create Comment 
    [HttpPost("/comments/create")]
    public IActionResult Create()
    {
        return RedirectToAction("Share", "Users"); // Redirect to Share page
    }
}