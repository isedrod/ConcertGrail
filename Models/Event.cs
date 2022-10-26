#pragma warning disable CS8618
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
namespace ConcertGrail.Models;

public class Event
{
    public string Title { get; set; }
    public string Url { get; set; }
    public Venue Venue { get; set; }
    public DateTime Datetime_local { get; set; }
}