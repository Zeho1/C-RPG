using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class Shorewood
    {
        public static int[][] tabContent;
        public static string[][] tabJeu;
        public static List<Monstre> ListeMobs = new List<Monstre>();
        public static List<Monstre> Pets = new List<Monstre>();
        public static Player Jacob;
        static int KillCount = 0;
        static bool EndFight = true;
        static bool EndGame = true;


        public static readonly List<Location> Locations = new List<Location>();
        public const int LOCATION_ID_VILLAGE = 1;
        public const int LOCATION_ID_FORET = 2;

        public static void PopulatePlaces()
        {
            Location Town = new Location(LOCATION_ID_VILLAGE, "Le Village");

            Location Forest = new Location(LOCATION_ID_FORET, "La foret de Shorewood");

            Locations.Add(Town);
            Locations.Add(Forest);
        }
        public static Location LocationByID(int id)
        {
            foreach (Location location in Locations)
            {
                if (location.ID == id)
                {
                    return location;
                }
            }

            return null;
        }
        public static int IDByLocation(Location location)
        {
            for (int i = 0; i < 11; i++)
            {
                if (location.ID == i)
                {
                    return i;
                }
            }
            return 0;
        }
        
        public static Player PopulateWorld(string[][] tabJeu, int[][] tabContent)
        {
            //Remplir de monstres le tableau 
            for (int i = 0; i < 12; i++)
            {
                //Creation Monstre
                De RandomMob = new De(3);
                int k = RandomMob.Lancer();
                Monstre M;

                switch (k)
                {
                    case 1:
                        M = new Loup();
                        break;
                    case 2:
                        M = new Orque();
                        break;
                    case 3:
                        M = new Dragonnet();
                        break;
                    default:
                        M = new Loup();
                        break;
                }
                //Ajout Monstre dans Liste/Tableau
                int cpt = 0;
                M.CharDown += MortPerso;
                do
                {
                    bool FuckThis = true;
                    //Positionnement
                    Random rnd = new Random();
                    M.CoordX = rnd.Next(0, 14);
                    M.CoordY = rnd.Next(0, 14);
                    foreach (Monstre K in ListeMobs)
                    {
                        if (Math.Abs(M.CoordX) < 2 && Math.Abs(M.CoordY - 7) < 2)
                        {
                            FuckThis = false;
                        }
                        if ((Math.Abs(M.CoordX - K.CoordX) + Math.Abs(M.CoordY - K.CoordY)) < 3)
                        {
                            FuckThis = false;
                        }
                    }
                    if (FuckThis)
                    {
                        ListeMobs.Add(M);
                        tabContent[M.CoordX][M.CoordY] = 1;
                        cpt++;
                    }
                }
                while (cpt == 0);
            }
            //Creer Heros
            int input = 0;
            bool Tryparse;
            Player Jacob;
            do
            {
                Console.WriteLine("Bonjour! Quelle race voulez-vous jouer? Nain = 1, Humain = 2, Nécro = 3");
                Tryparse = int.TryParse(Console.ReadLine(), out input);
            }
            while (!Tryparse);
            Console.WriteLine();
            switch (input)
            {
                case 1:
                    Jacob = new Nain();
                    Console.WriteLine("Excellent choix! It's Hammer Time!");
                    break;
                case 2:
                    Jacob = new Humain();
                    Console.WriteLine("Simple mais efficace!");
                    break;
                case 3:
                    Jacob = new Necro();
                    Console.WriteLine("La mort est votre alliée!");
                    break;
                default:
                    Jacob = new Humain();
                    break;
            }

            Console.WriteLine("Votre force est:" + Jacob.Force);
            Console.WriteLine("Votre endurance est :" + Jacob.Endurance);
            Jacob.PrintMaxHP();
            Console.WriteLine();

            //Location Town = new Location(LOCATION_ID_VILLAGE, "Le Village");

            //Location Forest = new Location(LOCATION_ID_FORET, "La foret de Shorewood");

            //Locations.Add(Town);
            //Locations.Add(Forest);

            //Jacob.CoordX = 7;
            //Jacob.CoordY = 7;
            //tabVillage[Jacob.CoordX][Jacob.CoordY] = " H ";
            //Jacob.CurrentLocation = Town;
            int cpt2 = 0;
            do
            {
                bool FuckThis2 = true;
                Random rnd = new Random();
                Jacob.CoordX = rnd.Next(0, 14);
                Jacob.CoordY = rnd.Next(0, 14);
                foreach (Monstre K in ListeMobs)
                {
                    if ((Math.Abs(Jacob.CoordX - K.CoordX) + Math.Abs(Jacob.CoordY - K.CoordY)) < 3)
                    {
                        FuckThis2 = false;
                    }
                }
                if (FuckThis2)
                {
                    tabContent[Jacob.CoordX][Jacob.CoordY] = 5;
                    tabJeu[Jacob.CoordX][Jacob.CoordY] = " H ";
                    cpt2++;
                }
            }
            while (cpt2 == 0);
            Jacob.CharDown += MortPerso;
            return Jacob;
        }
        
        public static void Jeu(Player Jacobs, string[][] tabActif)
        {
            Jacob = Jacobs;
            Console.ReadLine();
            

            do
            {
                
                //if (IDByLocation(Jacob.CurrentLocation) == 1)
                //{
                //    tabActif = tabVillage;
                //}
                //else
                //{
                //    tabActif = tabForet;
                //}
                //Tableaux.AffichageTableauString(tabActif);
                Tableaux.AffichageTableauString(tabActif);
                int x = 0;
                int y = 0;
                
                Console.WriteLine("Utilisez haut, bas, gauche et droite pour vous déplacer / Tuez tous les monstres!");
                ConsoleKey key = Console.ReadKey().Key;
                for (int i = 0; i < tabActif.Length; i++)
                {
                    for (int j = 0; j < tabActif[i].Length; j++)
                    {
                        if (tabActif[i][j] == " H ")
                        {
                            x = i;
                            y = j;
                        }
                    }
                }
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        if ((y >= 1) && (tabActif[x][y - 1] != " X ") && (tabActif[x][y - 1] != " + ") && (tabActif[x][y - 1] != " = "))
                        {
                            tabActif[x][y] = " . ";
                            tabActif[x][y - 1] = " H ";
                            Jacob.CoordY -= 1;
                        }
                        else Console.WriteLine("Déplacement impossible");
                        break;
                    case ConsoleKey.UpArrow:
                        if ((x >= 1) && (tabActif[x - 1][y] != " X ") && (tabActif[x - 1][y] != " + ") && (tabActif[x - 1][y] != " = "))
                        {
                            tabActif[x][y] = " . ";
                            tabActif[x - 1][y] = " H ";
                            Jacob.CoordX -= 1;
                        }
                        else Console.WriteLine("Déplacement impossible");
                        break;
                    case ConsoleKey.RightArrow:
                        if ((y < tabActif[x].Length - 1) && (tabActif[x][y + 1] != " X ") && (tabActif[x][y + 1] != " + ") && (tabActif[x][y + 1] != " = "))
                        {
                            tabActif[x][y] = " . ";
                            tabActif[x][y + 1] = " H ";
                            Jacob.CoordY += 1;
                        }
                        else Console.WriteLine("Déplacement impossible");
                        break;
                    case ConsoleKey.DownArrow:
                        if ((x < tabActif.Length - 1) && (tabActif[x + 1][y] != " X ") && (tabActif[x + 1][y] != " + ") && (tabActif[x + 1][y] != " = "))
                        {
                            tabActif[x][y] = " . ";
                            tabActif[x + 1][y] = " H ";
                            Jacob.CoordX += 1;
                        }
                        else Console.WriteLine("Déplacement impossible");
                        break;
                    default:
                        Console.WriteLine("Déplacement impossible");
                        break;
                }
                //if ((Math.Abs(Jacob.CoordX - PortForet.CoordX) + Math.Abs(Jacob.CoordY - PortForet.CoordY)) == 1)
                //{
                //    Console.WriteLine("Voulez-vous passer de l'autre côté? y/n");
                //    char move =  char.Parse(Console.ReadLine());
                //    if (move == 'y')
                //    {
                //        TransfertVersVillage(Jacob);
                //    }
                //}


                foreach (Monstre K in ListeMobs)
                {
                    if ((Math.Abs(Jacob.CoordX - K.CoordX) + Math.Abs(Jacob.CoordY - K.CoordY)) == 1)
                    {
                        Console.WriteLine("Vous êtes tombé sur un " + TrouverTypeMonstre(K) + " sauvage!! Il vous attaque!!");

                        if (TrouverTypeMonstre(K) == "Loup")
                        {
                            tabActif[K.CoordX][K.CoordY] = " L ";
                        }
                        else if (TrouverTypeMonstre(K) == "Orque")
                        {
                            tabActif[K.CoordX][K.CoordY] = " O ";
                        }
                        else
                        {
                            tabActif[K.CoordX][K.CoordY] = " D ";
                        }

                        Console.WriteLine("Le Monstre possède " + K.Force + " Force");
                        Console.WriteLine("Le Monstre possède " + K.Endurance + " Endurance");
                        K.PrintMaxHPMob();
                        Console.ReadLine();

                        Combat(Jacob, K);
                    }
                }
                if (KillCount == 12)
                {
                    Console.WriteLine("Bravo!! Vous avez clean cette foutue forêt!! Les paysans du coin seront ravis de l'apprendre");
                    Console.WriteLine("Vous avez amassé "+Jacob.Gold+" or et "+Jacob.CuirStack+" cuir");
                    EndGame = false;
                }
                Console.Clear();
            }
            while (EndGame);
        }
        public static void Combat(Player Jacobs, Monstre M)
        {
            
            EndFight = true;
            Jacobs.RefillHP();
            Console.WriteLine("Vous êtes bien reposé! PV aux max!");
            do
            {
                if (TrouverTypeJoueur(Jacobs) == "Nécromancien")
                {
                    foreach (Monstre L in Pets)
                    {
                        L.FrappePet(M);
                    }
                }
                Jacobs.Frappe(M);
                if (EndFight)
                {
                    M.Frappe(Jacobs);
                }
                Console.ReadLine();
            }
            while (EndFight);
            if (TrouverTypeJoueur(Jacobs) == "Nécromancien" && EndGame == true)
            {
                Console.WriteLine("Vous réanimez le " + TrouverTypeMonstre(M) + " pour combattre à vos côtés!!");
                Pets.Add(M);
                Console.ReadLine();
            }
            
        }

        public static string TrouverTypeMonstre(Monstre M)
        {
            if (M is Loup)
            {
                return "Loup";
            }
            else if (M is Orque)
            {
                return "Orque";
            }
            else
            {
                return "Dragonnet";
            }
        }
        public static string TrouverTypeJoueur(Player P)
        {
            if (P is Humain)
            {
                return "Humain";
            }
            else if (P is Nain)
            {
                return "Nain";
            }
            else
            {
                return "Nécromancien";
            }
        }

        private static void MortPerso(LivingThings David)
        {
            
            if (David is Monstre)
            {
                {
                    Console.WriteLine("Vous avez vaincu le monstre! C'est l'heure du loot");
                    Jacob.Gold += ((Monstre)David).LootGold; Console.WriteLine("Vous avez gagné " + ((Monstre)David).LootGold + " or");
                    Jacob.CuirStack += ((Monstre)David).LootCuir; Console.WriteLine("Vous avez gagné " + ((Monstre)David).LootCuir + " cuir");
                    
                    David.CoordX = 100; David.CoordY = 100;
                    KillCount++;
                    EndFight = false;
                }
            }
            else
            {
                Console.WriteLine("T'es Mort!! GG scrub git gut");
                EndGame = false;
                EndFight = false;
            }
        }
    }
}



