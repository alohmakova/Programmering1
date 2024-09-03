using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;

namespace ConsoleApp3
{
    class Program5
    {
        // detta är en statisk metod med en int som ett returvärde
        // metoden tar en parameter i form av ett random objekt av randomklassen
        static int RullaTärning(Random slumpObjekt)
        {
            slumpObjekt = new Random(); // skapar ett random objekt
            int speltal = slumpObjekt.Next(1, 7); // anropar Next metoden för att skapa ett slumptal mellan 1 och 6
            return speltal;// metoden returnerar det rullade värdet
        }
        static List<int> BubbleSort(List<int> tärn)//Sorteringsalgoritm för att sortera tärningarna som rullats
        {
            List<int> list = tärn;//Skapa listan
            int max = list.Count - 1;
            //Den yttre loopen, går genom hela listan
            for (int i = 0; i<max; i++)
            {
                //Den ingre loopen, går genom element för element
                int nrLeft = max - i;//hur många element som inte redan är färdigsorterade
                for (int j = 0; j < nrLeft; j++)
                {
                    if (list[j] > list[j+1])//jämför elementen
                    {
                        //byt plats
                        int temp = list[j];
                        list[j] = list[j+1];
                        list[j+1] = temp;
                    }

                }
            }
            return list;
        }
        
        static List<int> Valfritt(Random slumpObjekt, List<int> tärn, int speltal)//En metod som låter användaren rulla tärningar av valfritt antal sidor (10-sidig tärning, 20-sidig tärning, etc)
        {
            int antalSidor = 0;
            bool b = true;
            while (b)
            {
                Console.WriteLine("\n\tAnge antal sidor för dina tärningar: ");
            bool inmat = int.TryParse(Console.ReadLine(), out antalSidor);//Det första sättet med TryParse att undvika programkrasch om användaren inmatar något annat än ett heltal 

                if (inmat)
                {
                    slumpObjekt = new Random();
                    b = false;
                }
                else
                {
                    Console.Write("\n\tAnge ett heltal!");
                    continue;
                }
            }

            bool a = true;
            while (a)
            {
                Console.Write("\n\tHur många tärningar vill du rulla: ");

                bool inmatning = int.TryParse(Console.ReadLine(), out int antal);

                if (inmatning)
                {
                    
                    for (int i = 0; i < antal; i++)
                    {
                        speltal = slumpObjekt.Next(1, antalSidor + 1);
                        tärn.Add(speltal);
                    }
                    a = false;
                }
                else
                {
                    Console.Write("\n\tAnge ett heltal!");
                    continue;
                }
            }
            return tärn;
        }
        static List<int> BinärSökning(List<int> tärn)//Sökningsalgoritm för de rullade tärningarna 
        {
            
            if (tärn.Count > 0)//Om man sorterar en tom lista kommer man att få ett IndexOutOfRangeException
            {
                Console.WriteLine("\n\tVad vill du hitta? Skriv en siffra: ");

                //Det andra sättet med TryParse att undvika programkrasch om användaren inmatar något annat än ett heltal - det är kortare
                if (!int.TryParse(Console.ReadLine(), out int key))//Jag sparar en siffra som användaren har skrivit i en variabel [key]
                {
                    Console.WriteLine("\n\tAnge ett heltal!");
                    return tärn;
                }

                List<int> sortedTärn = new List<int>(tärn);// Skapa en kopia av listan
                sortedTärn.Sort();//Sortera kopia av listan, eftersom binär sökning kräver att listan är sorterad

                int first = 0;//index of 1 element
                int last = sortedTärn.Count - 1;//index of last element
            
            while (first <= last)
            {
                int mid = (first + last) /2;
                if (key > sortedTärn[mid])
                {
                    first = mid + 1;
                }
                else if (key < sortedTärn[mid])
                {
                    last = mid - 1;
                }
                else
                    {
                        int originalIndex = tärn.IndexOf(sortedTärn[mid]);//Hitta det ursprungliga indexet för det hittade elementet i den osorterade listan
                        Console.WriteLine("\n\tEn siffra " + key + " finns bland de rullade tärningarna på plats " + (originalIndex + 1));
                        return tärn;//Jag visar den osorterade listan för användaren
                    }
                }

                Console.WriteLine("\n\tEn siffra " + key + " finns inte bland de rullade tärningarna");//om den sökta siffran inte finns i listan
            }
            else
            {
                Console.WriteLine("\n\tDet finns inga sparade tärningsrull!"); //Om man sorterar en tom lista
            }

            List<int> ints = new List<int>();
            return ints;
        }
    
    static void Main()
        {
            Random slump = new Random(); // Skapar en instans av klassen Random för vårt slumptal /new Random()
            List<int> tärningar = new List<int>(); // listan för att spara våra rullade tärningar

            Console.WriteLine("\n\tVälkommen till tärningsgeneratorn!");

            bool kör = true; 
            while (kör)
            {
                Console.WriteLine("\n\t[1] Rulla tärning\n" +
                    "\t[2] Kolla vad du rullade\n" +
                    "\t[3] Rensa antalet tärningar som rullats\n" +                                       
                    "\t[4] Sök dina rullade tärningarna\n" +
                    "\t[5] Sortera tärningarna\n" +
                    "\t[6] Avsluta");
                Console.Write("\tVälj: ");
                int val;
                int.TryParse(Console.ReadLine(), out val);
                 

                switch (val)
                {
                    case 1:

                        /*Console.Write("\n\tHur många tärningar vill du rulla: ");
                        
                        bool inmatning = int.TryParse(Console.ReadLine(), out int antal);

                        if (inmatning)
                        {
                            
                            for (int i = 0; i < antal; i++)
                            {

                                // här kallar vi på metoden RullaTärning
                                // och sparar det returnerade värdet i 
                                // listan tärningar
                                tärningar.Add(RullaTärning(slump));
                            }
                        }*/
                        Valfritt(slump, tärningar, 0);
                        break;
                    case 2:
                        int sum = 0; // Skapar en int som ska innehålla medelvärdet av alla tärningsrullningar.
                        if (tärningar.Count <= 0)
                        {
                            Console.WriteLine("\n\tDet finns inga sparade tärningsrull! ");
                        }
                        else
                        {
                            Console.WriteLine("\n\tRullade tärningar: ");
                            foreach (int tärning in tärningar)
                            {
                                Console.WriteLine("\t" + tärning); 
                                sum = sum + tärning;//summan av alla tärningar
                            }
                            int medelvärdet = sum / tärningar.Count;//Medelvärde räknas ut genom att addera summan av alla tärningar i en och samma variabel, och dela summan med antal element i listan. 
                            Console.WriteLine("\n\tMedelvärdet på alla tärningsrull: " + medelvärdet); 
                        }

                        break;
                    case 3:
                        tärningar.Clear();//Möjligheten att rensa antalet tärningar som rullats
                        break;
                    case 4:
                        BinärSökning(tärningar);//metoden för att söka bland de tärningarna som rullats
                        break;
                    case 5:
                        //tärningar.Sort();//sortering 
                        BubbleSort(tärningar);//metoden för att sortera tärningarna som rullats
                        break;
                    case 6:
                        Console.WriteLine("\n\tTack för att du rullade tärning!");
                        Thread.Sleep(1000);
                        kör = false;
                        break;
                    default:
                        Console.WriteLine("\n\tVälj 1-6 från menyn.");
                        break;
                }
            }
        }
    }
}

