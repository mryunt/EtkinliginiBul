using EtkinliginiBul.Business.Abstract;
using EtkinliginiBul.DAL.Context;
using EtkinliginiBul.DAL.Dtos.EventType;
using EtkinliginiBul.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.Business.Concrete
{
    public class EventTypeService : IEventTypeService
    {
        public readonly EtkinliginiBulDbContext _etkinliginiBulDbContext;
        public EventTypeService(EtkinliginiBulDbContext etkinliginiBulDbContext)
        {
            _etkinliginiBulDbContext = etkinliginiBulDbContext;
        }

        public async Task<List<GetListEventTypeDto>> GetEventTypeList()
        {
            return await _etkinliginiBulDbContext.EventTypes.Where(p => !p.IsDeleted).Select(p => new GetListEventTypeDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToListAsync();
        }
        public async Task<GetEventTypeDto> GetEventTypeById(int id)
        {
            return await _etkinliginiBulDbContext.EventTypes.Where(p => !p.IsDeleted).Select(p => new GetEventTypeDto
            {
                Name = p.Name
            }).FirstOrDefaultAsync();
        }
        public async Task<int> AddEventType(AddEventTypeDto addEventTypeDto)
        {
            var newEventType = new EventType
            {
                Name = addEventTypeDto.Name
            };
            await _etkinliginiBulDbContext.EventTypes.AddAsync(newEventType);
            return await _etkinliginiBulDbContext.SaveChangesAsync();
        }
        public async Task<int> UpdateEventType(int id, UpdateEventTypeDto updateEventTypeDto)
        {
            var currentEventType = await _etkinliginiBulDbContext.EventTypes.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentEventType != null)
            {
                currentEventType.Name = updateEventTypeDto.Name;
                currentEventType.MDate = DateTime.Now;
                _etkinliginiBulDbContext.EventTypes.Update(currentEventType);
                return await _etkinliginiBulDbContext.SaveChangesAsync();
            }
            return -1;
        }

        public async Task<int> DeleteEventType(int id)
        {
            var currentEventType = await _etkinliginiBulDbContext.EventTypes.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentEventType != null)
            {
                currentEventType.IsDeleted = true;
                return await _etkinliginiBulDbContext.SaveChangesAsync();
            }
            return -1;
        }



    }
}
