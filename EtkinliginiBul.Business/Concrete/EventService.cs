using EtkinliginiBul.Business.Abstract;
using EtkinliginiBul.DAL.Context;
using EtkinliginiBul.DAL.Dtos.Event;
using EtkinliginiBul.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.Business.Concrete
{
    public class EventService : IEventService
    {
        public readonly EtkinliginiBulDbContext _etkinliginBulDbContext;
        public EventService(EtkinliginiBulDbContext etkinliginiBulDbContext)
        {
            _etkinliginBulDbContext = etkinliginiBulDbContext;
        }

        public async Task<List<GetListEventDto>> GetEvenList()
        {
            return await _etkinliginBulDbContext.Events.Include(p => p.EventTypeFK).Include(p => p.SalonFK).Where(p => !p.IsDeleted).Select(p => new GetListEventDto
            {
                Id = p.Id,
                Name = p.Name,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Explanation = p.Explanation,
                EventTypeName = p.EventTypeFK.Name,
                SalonName = p.SalonFK.Name
            }).ToListAsync();
        }
        public async Task<GetEventDto> GetEventById(int id)
        {
            return await _etkinliginBulDbContext.Events.Include(p => p.EventTypeFK).Include(p => p.SalonFK).Where(p => !p.IsDeleted && p.Id == id).Select(p => new GetEventDto
            {
                Name = p.Name,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Explanation = p.Explanation,
                EventTypeName = p.EventTypeFK.Name,
                SalonName = p.SalonFK.Name
            }).FirstOrDefaultAsync();
        }
        public async Task<int> AddEvent(AddEventDto addEventDto)
        {
            var newEvent = new Event
            {
                Name = addEventDto.Name,
                EventTypeId = addEventDto.EventTypeId,
                SalonId = addEventDto.SalonId,
                StartDate = addEventDto.StartDate,
                EndDate = addEventDto.EndDate,
                Explanation = addEventDto.Explanation,
            };
            await _etkinliginBulDbContext.Events.AddAsync(newEvent);
            return await _etkinliginBulDbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateEvent(int id, UpdateEventDto updateEventDto)
        {
            var currentEvent = await _etkinliginBulDbContext.Events.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentEvent != null)
            {
                currentEvent.Name = updateEventDto.Name;
                currentEvent.EventTypeId = updateEventDto.EventTypeId;
                currentEvent.SalonId = updateEventDto.SalonId;
                currentEvent.StartDate = updateEventDto.StartDate;
                currentEvent.EndDate = updateEventDto.EndDate;
                currentEvent.Explanation = updateEventDto.Explanation;
                currentEvent.MDate = DateTime.Now;
                _etkinliginBulDbContext.Events.Update(currentEvent);
                return await _etkinliginBulDbContext.SaveChangesAsync();
            }
            return -1;
        }
        public async Task<int> DeleteEvent(int id)
        {
            var currentEvent = await _etkinliginBulDbContext.Events.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentEvent != null)
            {
                currentEvent.IsDeleted = true;
                return await _etkinliginBulDbContext.SaveChangesAsync();
            }
            return -1;
        }



    }
}
