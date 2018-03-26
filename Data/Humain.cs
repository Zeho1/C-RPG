using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Humain : Player
    {
        public override int Force
        {
            get { return base.Force + 1; }
        }
        public override int Endurance
        {
            get { return base.Endurance + 1; }
        }
        public Humain() : base()
      
        {
        }
    
    }
}
