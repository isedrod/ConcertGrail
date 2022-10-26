#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ConcertGrail.Models;

public class Listing
{
    // === Fields ===
    [Key]
    public int ListingId { get; set; }

    [Required(ErrorMessage = "is required.")]
    [Display(Name = "Title")]
    public string Title { get; set; }

    [Required(ErrorMessage = "is required.")]
    [Display(Name = "Description")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "is required.")]
    [DataType(DataType.Currency)]
    [Display(Name = "Price")]
    public double Price { get; set; }

    //  public String PriceType { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // === Field Relationships ===
    public int UserId { get; set; }
    public User? User { get; set; }
}