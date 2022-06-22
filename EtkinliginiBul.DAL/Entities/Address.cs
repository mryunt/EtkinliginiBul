using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.DAL.Entities
{
    public class Address : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string AddressName { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }

        public ICollection<Salon> Salons { get; set; }

        public bool IsDeleted { get; set; }
    }
}
