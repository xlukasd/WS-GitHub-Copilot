using Microsoft.AspNetCore.Mvc;

namespace Quotes.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuoteController : ControllerBase
    {
        [HttpGet("qotd", Name = "quoteOfTheDay")]
        public Quote GetQuoteOfTheDay()
        {
            return new Quote();
        }
    }
}
