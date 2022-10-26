using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ConcertGrail.Models;
using Newtonsoft.Json;
namespace ConcertGrail.Controllers;     

public class EventsController : Controller
{
    // initialize base url
    string baseURL = "https://api.seatgeek.com/2/";
    string clientId = "?client_id=Mjk4MjY5MTZ8MTY2NjIzNDczNS45MjIyNzc";

    [HttpGet("/events")]
    public async Task<IActionResult> GetEvent()
    {
        Event thisEvent = new Event();
        using(var client = new HttpClient())
        {
            client.BaseAddress = new Uri(baseURL); // Adds base address
            client.DefaultRequestHeaders.Clear(); // Clears previous headers
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // specifies the type of response
            HttpResponseMessage response = await client.GetAsync("events/801255" + clientId); // submit request
            if (response.IsSuccessStatusCode) // check response success code 
            {
                var result = response.Content.ReadAsStringAsync().Result; // get data
                thisEvent = JsonConvert.DeserializeObject<Event>(result);
            }
        }

        return View("SearchEvents", thisEvent);
    }
}