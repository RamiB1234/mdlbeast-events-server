using mdlbeast_events_server.Models.Entities;
using mdlbeast_events_server.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace mdlbeast_events_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository eventRepository;

        public EventController(IEventRepository eventRepository) 
        {
            this.eventRepository = eventRepository;
        }

        [HttpGet]
        public List<Event> Get()
        {
            return eventRepository.GetEventList();
        }
    }
}
