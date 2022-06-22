using EtkinliginiBul.Business.Abstract;
using EtkinliginiBul.DAL.Context;
using EtkinliginiBul.DAL.Dtos.Address;
using EtkinliginiBul.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.Business.Concrete
{
    public class AddressService : IAddressService
    {
        public readonly EtkinliginiBulDbContext _etkinliginiBulDbContext;
        public AddressService(EtkinliginiBulDbContext etkinliginiBulDbContext)
        {
            _etkinliginiBulDbContext = etkinliginiBulDbContext;
        }

        public async Task<List<GetListAddressDto>> GetAddressList()
        {
            return await _etkinliginiBulDbContext.Addresses.Where(p => !p.IsDeleted).Select(p => new GetListAddressDto
                {
                    Id = p.Id,
                    AddressName = p.AddressName,
                    Lat = p.Lat,
                    Lng = p.Lng
                }).ToListAsync();
        }
        public async Task<GetAddressDto> GetAddressById(int id)
        {
            return await _etkinliginiBulDbContext.Addresses.Where(p => !p.IsDeleted && p.Id == id).Select(p => new GetAddressDto
                {
                    AddressName = p.AddressName,
                    Lat = p.Lat,
                    Lng = p.Lng
                }).FirstOrDefaultAsync();
        }
        public async Task<int> AddAddress(AddAddressDto addAddressDto)
        {
            var newAddress = new Address
            {
                AddressName = addAddressDto.AddressName,
                Lat = addAddressDto.Lat,
                Lng = addAddressDto.Lng
                
            };
            await _etkinliginiBulDbContext.Addresses.AddAsync(newAddress);
            return await _etkinliginiBulDbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAddress(int id, UpdateAddressDto updateAddressDto)
        {
            var currentAddress = await _etkinliginiBulDbContext.Addresses.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentAddress != null)
            {
                currentAddress.AddressName = updateAddressDto.AddressName;
                currentAddress.Lat = updateAddressDto.Lat;
                currentAddress.Lng = updateAddressDto.Lng;
                currentAddress.MDate = DateTime.Now;
                _etkinliginiBulDbContext.Addresses.Update(currentAddress);
                return await _etkinliginiBulDbContext.SaveChangesAsync();
            }
            return -1;
        }
        public async Task<int> DeleteAddress(int id)
        {
            var currentAddress = await _etkinliginiBulDbContext.Addresses.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentAddress != null)
            {
                currentAddress.IsDeleted = true;
                return await _etkinliginiBulDbContext.SaveChangesAsync();
            }
            return -1;
        }
    }
}
