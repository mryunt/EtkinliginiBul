using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.DAL.Entities
{
    public class Images : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int EventID { get; set; }
        public Event EventFK { get; set; }
        public bool IsDeleted { get; set; }
    }
}
