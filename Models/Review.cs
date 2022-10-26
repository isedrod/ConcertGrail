#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ConcertGrail.Models;

public class Review
{
    // === Fields ===
    [Key]
    public int ReviewId { get; set; }

    // TODO: eventId from api

    [Required(ErrorMessage = "is required.")]
    [Display(Name = "Rating")]
    public int Rating { get; set; }

    [Required(ErrorMessage = "is required.")]
    [Display(Name = "Description")]
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // === Field Relationships ===
    public int UserId { get; set; }
    public User? User { get; set; }
}