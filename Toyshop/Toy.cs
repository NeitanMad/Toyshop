using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toyshop
{
    internal class Toy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Frequency { get; set; }

        public Toy(int id, string name, int quantity, int weight)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Frequency = weight;
        }
    }
}
