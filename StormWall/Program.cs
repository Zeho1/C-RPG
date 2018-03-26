using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;


namespace StormWall
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] tabForet = Tableaux.CreationTableauForet();
            string[][] tabVillage = Tableaux.CreationTableauVillage();
            int[][] tabContent = Tableaux.CreationTableauData();
            Player Jacob = Shorewood.PopulateWorld(tabForet, tabContent);
            Tableaux.AffichageTableauString(tabVillage);
            Tableaux.AffichageTableauString(tabForet);
            Tableaux.AffichageTableauInt(tabContent);
            Console.WriteLine("Vous vous appelez Jacob. Les habitants du village vous ont engagés pour défendre leur habitations des attaques d'animaux sauvages provenant de la forêt de Shorewood.");
            Console.WriteLine("C'est donc la que vous vous rendez. Faites attention!");
            
            Shorewood.Jeu(Jacob, tabForet);
            Console.ReadLine();
        }
    }
}
