using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Dragonnet : Monstre
    {
       
        public override int Endurance
        {
            get { return base.Endurance + 1; }
        }

        public Dragonnet() : base()
        {
            De D = new De(4); De Dice = new De(6);
            LootGold = Dice.Lancer();
            LootCuir = D.Lancer();
        }
    }
}
