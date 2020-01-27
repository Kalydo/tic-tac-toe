using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        //Global damit diese Werte in der Schleife gespeichert werden.
        static string[] zahlen = new string[] { "1", "2", "3" ,  "4", "5", "6" ,  "7", "8", "9"  };
        static int playercount1 = 1;
        static int x;
        //Erwartet die Zahl im Raster und führt die Funktion kontrolle aus.
        static bool usereingabe()
        {
            try
            {
                //Erwartet die Eingabe des jeweiligen Spieler 
                Console.WriteLine("");
                Console.WriteLine("Spieler " + playercount1 + " du bist dran.");
                x = Int32.Parse(Console.ReadLine());
                //Ruft die Kontrollfuntion auf. Überprüfung ob Feld schon belegt ist. 
                if (kontrolle())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ungültige Eingabe versuch es nochmal.");
                Console.ReadKey();
                return false;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Ungültige Eingabe versuch es nochmal.");
                Console.ReadKey();
                return false;
            }

        }
        //Kontrolle der Eingabe falls nicht belegt, belegung des Zeichens des aktuellen Spielers.
        public static bool kontrolle()
        {
            // gibt ein false an usereingabe zurück da dieses feld schon belegt ist.
            try
            {
                if (zahlen[x - 1] == "X" || zahlen[x - 1] == "O")
                {
                    Console.WriteLine("Diese Feld ist schon belegt.");
                    Console.ReadKey();
                    return false;
                }
                //gibt je nach spieler der dran ist ein x oder o zurück 
                else if (playercount1 == 1)
                {
                    zahlen[x - 1] = "X";
                    return true;
                }
                else
                {
                    zahlen[x - 1] = "O";
                    return true;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ungültige Eingabe versuch es nochmal.");
                Console.ReadKey();
            }
            catch (IndexOutOfRangeException)
            { 
                return false;
            }
            {
                Console.WriteLine("Ungültige Eingabe versuch es nochmal.");
                Console.ReadKey();
                return false;
            }
       
        }
        
        static void Main(string[] args)
        {
            
            while (true)
            {
                //Bei jedem durchlauf wird das Raster refresht.
                Console.Clear();
                //Raster wird aufgebaut.
                Console.WriteLine("Sp1 = X | Sp2 = O");
                Console.WriteLine("");
                numbers();
                //Eingabe wird überprüft und Variable übergeben.
                bool nextplayer = usereingabe();
                //Ist die Siegesbedingung erfüllt wird das Programm gestoppt.
                if (win())
                {
                    Console.Clear();
                    Console.WriteLine("Sp1 = X | Sp2 = O");
                    Console.WriteLine("");
                    numbers();
                    Console.WriteLine("");
                    Console.WriteLine("Spieler " + playercount1 + " du hast Gewonnen!");
                    Console.ReadKey();
                    break;
                }
                //Anweisung um zu bestimmen ob der Spieler wechselt oder wegen besetztem Feld nochmal eingeben muss.
                if (nextplayer == true && playercount1 == 1)
                {
                    playercount1++;
                }
                else if (nextplayer == true && playercount1 == 2)
                {
                    playercount1--;
                }
                else
                {
                        
                }
            }   
        }
        //Überprüfung der Siegesbedingung.
        public static bool win()
        {
            //Vertikale überprüfung --
            if (zahlen[5] == zahlen[4] && zahlen[4] == zahlen[3])
            { 
                return true;
            }
            else if(zahlen[6] == zahlen[7] && zahlen[7] == zahlen[8])
            {
                return true;
            }
            else if (zahlen[0] == zahlen[1] && zahlen[1] == zahlen[2])
            {
                return true;
            }
            //Horizontale überprüfung  |
            else if (zahlen[0] == zahlen[3] && zahlen[3] == zahlen[6])
            {
                return true;
            }
            else if (zahlen[1] == zahlen[4] && zahlen[4] == zahlen[7])
            {
                return true;
            }
            else if (zahlen[2] == zahlen[5] && zahlen[5] == zahlen[8])
            {
                return true;
            }
            //Diagonale überprüfung /
            else if (zahlen[0] == zahlen[4] && zahlen[4] == zahlen[8])
            {
                return true;
            }
            else if (zahlen[2] == zahlen[4] && zahlen[4] == zahlen[6])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Aufbau des Visuellen-Rasters.
        static void numbers()
        {
            Console.WriteLine("   |   |   "); 
            Console.WriteLine(" {0} | {1} | {2} ", zahlen[0], zahlen[1], zahlen[2]);
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", zahlen[3], zahlen[4], zahlen[5]);
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", zahlen[6], zahlen[7], zahlen[8]);
            Console.WriteLine("   |   |   ");
        }
    }
}
