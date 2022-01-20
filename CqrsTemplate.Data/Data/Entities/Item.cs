using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsTemplate.Data.Data.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        
        public ICollection<Order> Orders { get; set; }
    }
}
