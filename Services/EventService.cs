using net_core_bootcamp_b1_mert.DTOs;
using net_core_bootcamp_b1_mert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_bootcamp_b1_mert.Services
{
    public interface IEventService
    {
        public string Add(EventAddDto model);
    }
    public class EventService:IEventService
    {
        private static IList<Event> data = new List<Event>();

        public string Add(EventAddDto model)
        {
            Event entity = new Event
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow
            };

            entity.Name = model.Name;
            entity.StartDate = model.StartDate;
            entity.FinishDate = model.FinishDate;
            entity.Location = model.Location;
            entity.isFree = model.isFree;
            entity.Price = model.Price;
            entity.Subject = model.Subject;
            entity.Desc = model.Desc;

            data.Add(entity);

            return "Eklendi";
        }

    }
}
