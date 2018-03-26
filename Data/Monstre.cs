using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Monstre : LivingThings
    {
        public int LootGold { get; set; }
        public int LootCuir { get; set; }

        public Monstre() : base()
        {
        }
            
    }
}
