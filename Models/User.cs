#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ConcertGrail.Models;

public class User
{
    // === Fields ===
    [Key]
    public int UserId { get; set; }

    [Required(ErrorMessage = "is required.")]
    [Display(Name = "Username")]
    public string Username { get; set; }

    [Required(ErrorMessage = "is required.")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "is required.")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "is required.")]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "is required.")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [NotMapped]
    [Required(ErrorMessage = "is required.")]
    [Compare("Password", ErrorMessage = "Passwords must match.")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; }

    // TODO: Add account type (general, artist)

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // === Field Relationships ===
    public List<Post> Posts { get; set; } = new List<Post>();
    public List<Listing> Listings { get; set; } = new List<Listing>();
    public List<Review> Reviews { get; set; } = new List<Review>();
}