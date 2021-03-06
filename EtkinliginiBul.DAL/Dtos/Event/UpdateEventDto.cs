using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.DAL.Dtos.Event
{
    public class UpdateEventDto
    {
        public string Name { get; set; }
        public int EventTypeId { get; set; }
        public int SalonId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Explanation { get; set; }
    }
}
