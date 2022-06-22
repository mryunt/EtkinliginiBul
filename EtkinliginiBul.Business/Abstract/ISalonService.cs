using AppCore.Entity;
using EtkinliginiBul.DAL.Dtos.Salon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.Business.Abstract
{
    public interface ISalonService : IEntity
    {
        public Task<List<GetListSalonDto>> GetSalonList();
        public Task<GetSalonDto> GetSalonById(int id);
        public Task<int> AddSalon(AddSalonDto addSalonDto);
        public Task<int> UpdateSalon(int id, UpdateSalonDto updateSalonDto);
        public Task<int> DeleteSalon(int id);
    }
}
