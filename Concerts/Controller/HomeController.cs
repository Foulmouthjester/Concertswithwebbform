using Microsoft.AspNetCore.Mvc;
using ConcertApp.Models;

namespace ConcertApp.Controllers
{
  public class HomeController : Controller
  {
    // GET: Index (or other name for the site)
    public IActionResult Index()
    {
      return Content(@"
                <!DOCTYPE html>
                <html lang='en'>
                <head>
                    <meta charset='UTF-8'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <title>Add Concert</title>
                </head>
                <body>
                    <h1>Add a New Concert</h1>
                    <form method='post' action='/Home/ShowConcert'>
                        <label for='name'>Concert Name:</label>
                        <input type='text' id='name' name='Name' required><br><br>

                        <label for='date'>Date:</label>
                        <input type='date' id='date' name='Date' required><br><br>

                        <label for='venue'>Venue:</label>
                        <input type='text' id='venue' name='Venue' required><br><br>

                        <button type='submit'>Add Concert</button>
                    </form>
                </body>
                </html>
            ");
    }

    // POST: ShowConcert (form submission)
    [HttpPost]
    public IActionResult ShowConcert(Concert concert)
    {
      // Ensure the response is treated as HTML
      Response.ContentType = "text/html";

      // Build the result string with the concert details
      string result = $@"
                <!DOCTYPE html>
                <html lang='en'>
                <head>
                    <meta charset='UTF-8'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <title>Concert Details</title>
                </head>
                <body>
                    <h1>Concert Details</h1>
                    <p><strong>Name:</strong> {concert.Name}</p>
                    <p><strong>Date:</strong> {concert.Date}</p>
                    <p><strong>Venue:</strong> {concert.Venue}</p>
                    <br>
                    <a href='/Index.html'>Back to Add Concert</a>
                </body>
                </html>
            ";

      // Return the content
      return Content(result);
    }
  }
}

