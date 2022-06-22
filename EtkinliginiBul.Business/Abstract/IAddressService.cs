using AppCore.Entity;
using EtkinliginiBul.DAL.Dtos.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.Business.Abstract
{
    public interface IAddressService : IEntity
    {
        public Task<List<GetListAddressDto>> GetAddressList();
        public Task<GetAddressDto> GetAddressById(int id);
        public Task<int> AddAddress(AddAddressDto addAddressDto);
        public Task<int> UpdateAddress(int id, UpdateAddressDto updateAddressDto);
        public Task<int> DeleteAddress(int id);
    }
}
