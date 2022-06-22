using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.DAL.Entities
{
    public class Seat : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string SeatNo { get; set; }
        public int SeatPrice { get; set; }
        public int SalonID { get; set; }
        public Salon SalonFK { get; set; }
        public bool IsDeleted { get; set; }
    }
}
