using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using again.Interface;
using again.Models;
using Microsoft.EntityFrameworkCore;

namespace again.Concrete
{
    public class EventRepository : IEventRepository
    {
        private readonly againContext _dbContext;

        public EventRepository(againContext dbContext)
        {
            _dbContext = dbContext;
        }

        //gets azll events ordered by date
        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _dbContext.Event.OrderBy(e => e.DateTime).ToListAsync();
        }

        //get events by Active status 
        public async Task<IEnumerable<Event>> GetEventsActive(bool isActive)
        {
            return await _dbContext.Event.Where(e => e.Active == isActive).ToListAsync();
        }
    }
}
