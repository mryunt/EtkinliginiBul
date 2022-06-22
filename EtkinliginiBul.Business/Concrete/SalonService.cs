using EtkinliginiBul.Business.Abstract;
using EtkinliginiBul.DAL.Context;
using EtkinliginiBul.DAL.Dtos.Salon;
using EtkinliginiBul.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.Business.Concrete
{
    public class SalonService : ISalonService
    {
        public readonly EtkinliginiBulDbContext _etkinliginiBulDbContext;
        public SalonService(EtkinliginiBulDbContext etkinliginiBulDbContext)
        {
            _etkinliginiBulDbContext = etkinliginiBulDbContext;
        }

        public async Task<List<GetListSalonDto>> GetSalonList()
        {
            return await _etkinliginiBulDbContext.Salons.Include(p => p.AddressFK).Where(p => !p.IsDeleted).Select(p => new GetListSalonDto
            {
                Id = p.Id,
                Name = p.Name,
                Address = p.AddressFK.AddressName
            }).ToListAsync();
        }
        public async Task<GetSalonDto> GetSalonById(int id)
        {
            return await _etkinliginiBulDbContext.Salons.Include(p => p.AddressFK).Where(p => !p.IsDeleted).Select(p => new GetSalonDto
            {
                Name = p.Name,
                Address = p.AddressFK.AddressName
            }).FirstOrDefaultAsync();
        }
        public async Task<int> AddSalon(AddSalonDto addSalonDto)
        {
            var newSalon = new Salon
            {
                Name = addSalonDto.Name,
                AddresId = addSalonDto.AddressId
            };
            await _etkinliginiBulDbContext.Salons.AddAsync(newSalon);
            return await _etkinliginiBulDbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateSalon(int id, UpdateSalonDto updateSalonDto)
        {
            var currentSalon = await _etkinliginiBulDbContext.Salons.Where(p => !p.IsDeleted).FirstOrDefaultAsync();
            if (currentSalon != null)
            {
                currentSalon.Name = updateSalonDto.Name;
                currentSalon.AddresId = updateSalonDto.AddressId;
                currentSalon.MDate = DateTime.Now;
                _etkinliginiBulDbContext.Salons.Update(currentSalon);
                return await _etkinliginiBulDbContext.SaveChangesAsync();
            }
            return -1;
        }
        public async Task<int> DeleteSalon(int id)
        {
            var currentSalon = await _etkinliginiBulDbContext.Salons.Where(p => !p.IsDeleted).FirstOrDefaultAsync();
            if (currentSalon != null)
            {
                currentSalon.IsDeleted = true;
                return await _etkinliginiBulDbContext.SaveChangesAsync();
            }
            return -1;
        }



    }
}
