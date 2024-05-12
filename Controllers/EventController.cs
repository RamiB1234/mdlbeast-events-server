using mdlbeast_events_server.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace mdlbeast_events_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        [HttpGet(Name = "GetEvents")]
        public List<Event> Get()
        {
            return new List<Event> {
                new Event
                {
                    Id=1,
                    Description= "aaa",
                    Name= "mdlbeast",
                    Date="11/11/1111"
                }
            };
        }
    }
}
