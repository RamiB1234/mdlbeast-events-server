using mdlbeast_events_server.Models.Entities;
using mdlbeast_events_server.Models.Repository;
using mdlbeast_events_server.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mdlbeast_events_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly IEmailSender emailSender;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ITicketRepository ticketRepository;

        public TicketController(ITicketRepository ticketRepository, IWebHostEnvironment webHostEnvironment,  IEmailSender emailSender)
        {
            this.ticketRepository = ticketRepository;
            this.webHostEnvironment = webHostEnvironment;
            this.emailSender = emailSender;
        }

        [HttpPost]
        public async Task<StatusCodeResult> Post([FromBody] Ticket ticket)
        {
            try
            {
                ticketRepository.SaveTicket(ticket);

                // Send notification email
                string emailBody = System.IO.File.ReadAllText(Path.Combine(webHostEnvironment.WebRootPath,
                    "EmailTemplates", "TicketConfirm.html"));
                emailBody = emailBody.Replace("{NAME}", ticket.Name);
                emailBody = emailBody.Replace("{EVENT_NAME}", ticket.EventName);
                emailBody = emailBody.Replace("{TICKET_NO}", ticket.TicketNumber);

                var message = new Models.EmailEntities.Message(new string[] { ticket.Email },
                    $"MDLBeast Ticket Confirmation", emailBody);
                await emailSender.SendEmailAsync(message);

                return Ok();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.InnerException?.ToString());
                return BadRequest();
            }
        }

        [HttpGet]
        [Authorize]
        public List<Ticket> Get()
        {
            return ticketRepository.GetTicketList();

        }
    }
}
