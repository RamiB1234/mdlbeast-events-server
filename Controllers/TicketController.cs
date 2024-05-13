using mdlbeast_events_server.Models.Entities;
using mdlbeast_events_server.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace mdlbeast_events_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository ticketRepository;

        public TicketController(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }

        [HttpPost]
        public StatusCodeResult Post([FromBody] Ticket ticket)
        {
            try
            {
                ticketRepository.SaveTicket(ticket);
                return Ok();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.InnerException?.ToString());
                return BadRequest();
            }
        }
    }
}
