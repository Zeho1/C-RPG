using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Player : LivingThings
    {
        public int Gold { get; set; }
        public int CuirStack { get; set; }
        public Location CurrentLocation { get; set; }
        public Player(): base()
        {
        } 
    }

}
