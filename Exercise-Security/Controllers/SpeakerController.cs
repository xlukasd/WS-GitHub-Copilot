using System.Text.Json.Nodes;
using Exercise_Security.Model;
using Exercise_Security.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Exercise_Security.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpeakerController : ControllerBase
    {
        private SessionManagerDbContext SessionManagerDbContext { get; }

        public SpeakerController(SessionManagerDbContext sessionManagerDbContext)
        {
            SessionManagerDbContext = sessionManagerDbContext;
        }

        [HttpGet(Name = "GetAllSpeakers")]
        public async Task<ActionResult> GetAllSpeakers(Guid id)
        {
            return Ok();
        }

        [HttpPatch(Name = "UpdateSpeaker")]
        public void UpdateSpeaker(Guid speakerId, [FromBody] JsonObject jsonObject)
        {
            var speaker = SessionManagerDbContext.Speakers.Find(speakerId);
            if (speaker == null)
            {
                return;
            }

            SessionManagerDbContext.SaveChanges();
        }

        private void UpdateSpeakerInternal(Speaker speaker, JsonObject jsonObject)
        {
        }
    }
}
