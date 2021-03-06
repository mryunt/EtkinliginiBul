using AppCore.Entity;
using EtkinliginiBul.DAL.Dtos.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.Business.Abstract
{
    public interface IEventService : IEntity
    {
        public Task<List<GetListEventDto>> GetEvenList();
        public Task<GetEventDto> GetEventById(int id);
        public Task<int> AddEvent(AddEventDto addEventDto);
        public Task<int> UpdateEvent(int id, UpdateEventDto updateEventDto);
        public Task<int> DeleteEvent(int id);
    }
}
