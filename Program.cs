using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Loggboken
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n\tVad heter du? : ");
            Console.Title = (Console.ReadLine() + "'s loggbok");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            DateTime datum = DateTime.Now;

            List<string[]> loggBok = new List<string[]>();
            string[] post = new string[3];
            int loop = 0;

            // Här över så har jag sparat allt som måste finnas utanför while loopen

            while (loop == 0)
            {
                Console.Clear();
                Console.WriteLine("\n\t-Välkommen till loggboken-");
                Console.WriteLine("\n\t[1] Skriv ut alla inlägg");
                Console.WriteLine("\n\t[2] Skriv nytt inlägg i loggboken");
                Console.WriteLine("\n\t[3] Sök bland inlägg");
                Console.WriteLine("\n\t[4] Avsluta");
                Console.Write("\n\tMenyval: ");

                int tal;
                bool lyckat = Int32.TryParse(Console.ReadLine(), out tal);
                if (lyckat)
                {
                    switch (tal)
                    {
                        case 1: 
                            // Denna koden låter dig skriva ut alla inlägg som du skapat.

                            Console.Clear();
                            Console.WriteLine("\n\t-Tryck enter för att återgå till menyn-");
                            for (int i = 0; i < loggBok.Count; i++)
                            {
                                Console.WriteLine("\n\t" + i + " - Inlägget skrevs " + loggBok[i][2] +
                                "\n\t    Titel: " + loggBok[i][0] + " \n\n\t    " + loggBok[i][1]);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 2: 
                            // Denna kod låter dig skapa nya inlägg och spara dem.

                            Console.Clear();
                            string[] newpost = new string[3];
                            Console.WriteLine("\n\tNytt inlägg");
                            Console.Write("\n\tTitel: ");
                            string titel = Console.ReadLine();
                            newpost[0] = titel;
                            
                            Console.Write("\n\tText: ");
                            string text = Console.ReadLine();
                            newpost[1] = text;

                            string now = Convert.ToString(datum);
                            datum = DateTime.Now;
                            newpost[2] = now;

                            
                            post = newpost;
                            loggBok.Add(post);
                            Console.Clear();
                            break;

                        case 3: 
                            // Denna kod låter dig söka efter dina inlägg genom antigen texten eller titeln på inlägget

                            Console.Clear();
                            Console.Write("\n\t Titel eller text på inlägget du söker: ");
                            string key = Console.ReadLine();
                            bool hittades = false;

                            if (loggBok.Count > 0) // hanterar fel
                            {
                                for (int i = 0; i < loggBok.Count; i++)
                                {
                                    foreach (var posts in loggBok[i])
                                    {
                                        if (key == posts)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("\n\t-Tryck enter för att återgå till menyn-");
                                            Console.WriteLine("\n\t" + loggBok[i][2] + "\n\tTitel: " + loggBok[i][0] + "\n\n\t"  + loggBok[i][1]);
                                            hittades = true;
                                            Console.ReadKey();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                // Hanterar fel
                                Console.Clear();
                                Console.WriteLine("\n\t-Tryck enter för att återgå till menyn-");
                                Console.WriteLine("\n\t Du har inga sparade inlägg");
                                Console.ReadKey();
                            }
                            if (hittades == false && loggBok.Count > 0)
                            {
                                // Hanterar fel
                                Console.Clear();
                                Console.WriteLine("\n\t-Tryck enter för att återgå till menyn-");
                                Console.WriteLine("\n\tDitt inlägg hittades inte");
                                Console.ReadKey();
                            }
                            break;

                        case 4: 
                              // Denna kod stänger ner programmet genom att öka loop med 1

                            Console.Clear();
                            loop++;
                            break;

                        default:
                            // Hanterar fel
                            Console.Clear();
                            Console.WriteLine("\n\tfelaktigt menyval, tryck enter för att återvända till menyn");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                else
                {
                    // Hanterar fel
                    Console.Clear();
                    Console.WriteLine("\n\tFelaktigt menyval, använd endast siffror, tryck enter för att återvända till menyn");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}