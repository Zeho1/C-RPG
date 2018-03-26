using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public delegate void DelegateDeath(LivingThings Char);
    public abstract class LivingThings
    {
        private int _currentHitPoints;
        private int _force;
        private int _endurance;
        public virtual int Force
        {
            get { return _force; }
        }
        public virtual int Endurance
        {
            get { return _endurance; }
        }
        private int MaxHitPoints { get; set; }
        private int CurrentHitPoints
        {
            get { return _currentHitPoints; }
            set
            {
                bool DejaMort = false;
                if (CurrentHitPoints <= 0)
                {
                    DejaMort = true;
                }
                _currentHitPoints = value;
                if (DejaMort == false && CurrentHitPoints <=0)
                {
                    
                    CharDown(this);
                }
            }
        }

        public event DelegateDeath CharDown = null;

        public int CoordX { get; set; }
        public int CoordY { get; set; }

        public LivingThings()
        {
            De D = new De(6);
            _force = De.StatGen();
            _endurance = De.StatGen();
            MaxHitPoints = Endurance + De.TestValueGenerator(Endurance);
            CurrentHitPoints = MaxHitPoints;
        }

        public void Frappe(LivingThings Target)
        {
            De Dice = new De(4);
            int damageToLivingThings = Dice.Lancer() + De.TestValueGenerator(Force);
            Target.CurrentHitPoints -= damageToLivingThings;
            if (Target is Monstre)
            {
                Console.WriteLine("Joli coup!");
                Console.WriteLine("Il reste " + Target.CurrentHitPoints + " PV au monstre");
            }
            else
            {
                Console.WriteLine("Le monstre vous attaque!!");
                Console.WriteLine("Outch! Il vous reste " + Target.CurrentHitPoints + " PV");
            }

        }

        public void FrappePet(LivingThings Target)
        {
            De Dice = new De(2);
            int damageToLivingThings = Dice.Lancer();
            Console.WriteLine("Votre animal réanimé attaque le monstre!");
            Target.CurrentHitPoints -= damageToLivingThings;
            Console.WriteLine("Il reste " + Target.CurrentHitPoints + " PV au monstre");
        }

        public void PrintMaxHP()
        {
            Console.WriteLine("Vos PV totaux sont égaux à : "+MaxHitPoints);
        }
        public void PrintMaxHPMob()
        {
            Console.WriteLine("Le Monstre possède : " + MaxHitPoints);
        }
       
        public void RefillHP()
        {
            CurrentHitPoints = MaxHitPoints;
        }





    }
}


