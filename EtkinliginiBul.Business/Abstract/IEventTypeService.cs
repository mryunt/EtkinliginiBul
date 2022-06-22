using AppCore.Entity;
using EtkinliginiBul.DAL.Dtos.EventType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.Business.Abstract
{
    public interface IEventTypeService : IEntity
    {
        public Task<List<GetListEventTypeDto>> GetEventTypeList();
        public Task<GetEventTypeDto> GetEventTypeById(int id);
        public Task<int> AddEventType(AddEventTypeDto addEventTypeDto);
        public Task<int> UpdateEventType(int id, UpdateEventTypeDto updateEventTypeDto);
        public Task<int> DeleteEventType(int id);
    }
}
