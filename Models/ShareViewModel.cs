#pragma warning disable CS8618
using ConcertGrail.Models;
using System.ComponentModel.DataAnnotations;
namespace ConcertGrail.Models;

public class ShareViewModel
{
    public IEnumerable<Post> Posts { get; set; }
    public IEnumerable<Review> Reviews { get; set; }
    public IEnumerable<Listing> Listings { get; set; }
}