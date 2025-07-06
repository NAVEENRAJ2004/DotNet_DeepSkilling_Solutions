using System.Collections.Generic;
using RetailInventory.models;

namespace RetailInventory.models
{
    public class category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<product> Products { get; set; } = new List<product>();
    }
}
