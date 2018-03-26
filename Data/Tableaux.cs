using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class Tableaux
    {
        public static string[][] CreationTableauVillage()
        {
            //Création du tableau de jeu/vision du village
            string[][] tabVillage = new string[15][];
            for (int i = 0; i < tabVillage.Length; i++)
            {
                tabVillage[i] = new string[15];
            }
            //BASE
            for (int i = 0; i < tabVillage.Length; i++)
            {
                for (int j = 0; j < tabVillage[i].Length; j++)
                {
                    tabVillage[i][j] = " . ";
                }

            }
            //TAVERNE
            for (int i = 1; i < 3; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    tabVillage[i][j] = " X ";
                }

            }
            tabVillage[3][3] = " + ";
            //HOME
            tabVillage[2][8] = " X ";
            tabVillage[2][9] = " X ";
            tabVillage[3][8] = " X ";
            tabVillage[3][9] = " X ";
            tabVillage[4][8] = " + ";
            //FORGE
            for (int i = 5; i < 8; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    tabVillage[i][j] = " X ";
                }

            }
            tabVillage[8][4] = " + ";
            //TRAVAILCUIR
            for (int i = 6; i < 8; i++)
            {
                for (int j = 9; j < 13; j++)
                {
                    tabVillage[i][j] = " X ";
                }

            }
            tabVillage[8][11] = " + ";
            //MAIRIE
            for (int i = 10; i < 15; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    tabVillage[i][j] = " X ";
                }

            }
            tabVillage[12][4] = " + ";
            //ACCES FORET
            tabVillage[14][7] = " = ";
            Portal PortVillage = new Portal(14, 7);
            return tabVillage;
        }
        public static string[][] CreationTableauForet()
        {
            //Création du 2eme tableau de jeu/vision de la foret
            string[][] tabJeu = new string[15][];
            for (int i = 0; i < tabJeu.Length; i++)
            {
                tabJeu[i] = new string[15];
            }
            for (int i = 0; i < tabJeu.Length; i++)
            {
                for (int j = 0; j < tabJeu[i].Length; j++)
                {
                    tabJeu[i][j] = " . ";
                }

            }
            tabJeu[0][7] = " = ";
            return tabJeu;
        }
        //3eme tableau pour le contenu de la foret
        public static int[][] CreationTableauData()
        {
            int[][] tabContent = new int[15][];
            for (int i = 0; i < 15; i++)
            {
                tabContent[i] = new int[15];
            }

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    tabContent[i][j] = 0;
                }

            }
            return tabContent;
        }

        public static void AffichageTableauString(string[][] tabJeu)
        {
            //Affichage tabJeu/vision
            for (int i = 0; i < tabJeu.Length; i++)
            {
                for (int j = 0; j < tabJeu[i].Length; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(tabJeu[i][j] + " ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        public static void AffichageTableauInt(int[][] tabJeu)
        {
            //Affichage tabContent/Data cachée
            for (int i = 0; i < tabJeu.Length; i++)
            {
                for (int j = 0; j < tabJeu[i].Length; j++)
                {
                    if (tabJeu[i][j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(tabJeu[i][j] + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(tabJeu[i][j] + " ");
                        Console.ResetColor();
                    }

                }
                Console.WriteLine();
            }
        }
    }
}
