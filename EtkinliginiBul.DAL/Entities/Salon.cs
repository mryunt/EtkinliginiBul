using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.DAL.Entities
{
    public class Salon : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddresId { get; set; }
        public Address AddressFK { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Seat> Seats { get; set; }
        public bool IsDeleted { get; set; }
    }
}
