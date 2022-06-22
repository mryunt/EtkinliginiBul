using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.DAL.Dtos.Address
{
    public class GetListAddressDto
    {
        public int Id { get; set; }
        public string AddressName { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
    }
}
