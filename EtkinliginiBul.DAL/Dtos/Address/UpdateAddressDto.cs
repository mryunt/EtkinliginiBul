using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.DAL.Dtos.Address
{
    public class UpdateAddressDto
    {
        public string AddressName { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
    }
}
