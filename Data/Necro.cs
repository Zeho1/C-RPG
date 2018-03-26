using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Necro : Player
    {
        public override int Force
        {
            get { return base.Force +12; }
        }
        public override int Endurance
        {
            get { return base.Endurance +12; }
        }
        public Necro() : base()

        {
        }

    }
    
    
}
