using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Data
{
    public class De
    {
        public Random _generator = new Random();
        public RNGCryptoServiceProvider Gen = new RNGCryptoServiceProvider();
        public int Minimum { get; }
        public int Maximum { get; }

        public De(int nbFaces)
        {
            Minimum = 1;
            Maximum = nbFaces;
        }
        public int Lancer()
        {
            int alea = NumberBetween(Minimum, Maximum);
            return alea;
        }
        public static int StatGen()
        {
            int[] tab = new int[4];
            for (int i = 0; i < 4; i++)
            {
                tab[i] = new De(6).Lancer();
            }
            int cpt = 4;
            while (cpt > 0)
                for (int j = 0; j < 3; j++)
                {
                    if (tab[j] > tab[j + 1])
                    {
                        int temp = tab[j];
                        tab[j] = tab[j + 1];
                        tab[j + 1] = temp;
                    }
                    cpt--;
                }

            int valeur = tab[1] + tab[2] + tab[3];
            return valeur;
        }

        //public static int StatsValueGenerator()
        //{
        //    int a = DeSix(); int b = DeSix(); int c = DeSix(); int d = DeSix();
        //    var list = new[] { a, b, c, d };
        //    int min = list.Min();
        //    int Value = a + b + c + d - min;
        //    return Value;
        //}
        public static int TestValueGenerator(int Carac)
        {
            if (Carac < 5)
            {
                int Value = -1;
                return Value;
            }
            else if (Carac < 10)
            {
                return 0;
            }
            else if (Carac < 15)
            {
                int Value = 1;
                return Value;
            }
            else
            {
                int Value = 2;
                return Value;
            }
        }
        public int NumberBetween(int minimumValue, int maximumValue)
        {
            byte[] randomNumber = new byte[1];

            Gen.GetBytes(randomNumber);

            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

            // We are using Math.Max, and substracting 0.00000000001,
            // to ensure "multiplier" will always be between 0.0 and .99999999999
            // Otherwise, it's possible for it to be "1", which causes problems in our rounding.
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);

            // We need to add one to the range, to allow for the rounding done with Math.Floor
            int range = maximumValue - minimumValue + 1;

            double randomValueInRange = Math.Floor(multiplier * range);

            return (int)(minimumValue + randomValueInRange);
        }

    }
}

