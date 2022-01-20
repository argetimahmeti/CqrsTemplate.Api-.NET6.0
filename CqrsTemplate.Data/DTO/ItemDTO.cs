using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsTemplate.Data.DTO
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
