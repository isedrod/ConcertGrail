#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ConcertGrail.Models;

public class Comment
{
    // === Fields ===
    [Key]
    public int CommentId { get; set; }

    [Required(ErrorMessage = "is required.")]
    [Display(Name = "Message")]
    public string Message { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // === Field Relationships ===
    public int PostId { get; set; }
}