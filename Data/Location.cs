using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Location(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
