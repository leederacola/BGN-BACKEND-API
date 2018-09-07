using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using again.Models;
using again.Interface;
using Microsoft.AspNetCore.Cors;

namespace again.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("LocalTest")]
    [ApiController]
    public class EventApiController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventApiController(IEventRepository eventrepository)
        {
            _eventRepository = eventrepository;
        }

        //GET: api/events
        [Route("")]
        [HttpGet]
        public Task<IEnumerable<Event>> GetAllEvents()
        {
            var events = _eventRepository.GetAllEvents();
            return events;
        }
     }
}