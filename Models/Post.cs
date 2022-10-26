#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ConcertGrail.Models;

public class Post
{
    // === Fields ===
    [Key]
    public int PostId { get; set; }

    [Required(ErrorMessage = "is required.")]
    [Display(Name = "Subject")]
    public string Subject { get; set; }

    [Required(ErrorMessage = "is required.")]
    [Display(Name = "Message")]
    public string Message { get; set; }

    // TODO: add field for Tags

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // === Field Relationships ===
    public int UserId { get; set; }
    public User? User { get; set; }
    public List<Comment> Comments { get; set; } = new List<Comment>();
}