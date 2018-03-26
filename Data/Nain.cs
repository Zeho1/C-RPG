using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Nain : Player
    {
        public override int Force
        {
            get { return base.Force; }
        }
        public override int Endurance
        {
            get { return base.Endurance + 2; }
        }
        public Nain(): base()
        {
        }
    }
}
