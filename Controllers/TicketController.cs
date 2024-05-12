using mdlbeast_events_server.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace mdlbeast_events_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        [HttpPost]
        public StatusCodeResult Post([FromBody] Ticket ticket)
        {
            return Ok();
        }
    }
}
