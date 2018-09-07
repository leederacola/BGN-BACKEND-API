using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using again.Models;

namespace again.Interface
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<IEnumerable<Event>> GetEventsActive(bool isActive);
    }
}
