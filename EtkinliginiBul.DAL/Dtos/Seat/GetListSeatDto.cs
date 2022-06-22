using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.DAL.Dtos.Seat
{
    public class GetListSeatDto
    {
        public int Id { get; set; }
        public int SalonId { get; set; }
        public string SeatNo { get; set; }
        public int SeatPrice { get; set; }

    }
}
