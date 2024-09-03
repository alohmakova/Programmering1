using System;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace MyApp
{
    internal class Program4
    {
        //metoder
        static void VisaMeny()
        {
            Console.WriteLine("\nVälkommen till ryggsäcken!");//detta är programmenyn, som består av 5 punkter
            Console.WriteLine("\n[1] Lägg till 5 föremål i din ryggsäck");
            Console.WriteLine("[2] Skriv ut innehållet");
            Console.WriteLine("[3] Sök efter föremålet i ryggsäcken");
            Console.WriteLine("[4] Rensa innehållet av ryggsäcken");
            Console.WriteLine("[5] Avsluta");
            Console.Write("\n\tVälj: ");
        }
        static string[] LäggTill()
        {
            string[] vektor = new string[5];
            Console.Write("\n\tLägg till 5 föremål i din ryggsäck: ");

            for (int i = 0; i < vektor.Length; i++) // Jag använder en for-loop för att tilldela ett strängvärde till varje element
            {
                Console.Write("\nFöremål " + (i + 1) + ": ");
                vektor[i] = Console.ReadLine();
            }

            return vektor;
        }

        static string[] VisaInnehållet(string[] vektor) 
        {
            Console.WriteLine("\n\tRyggsäcken innehåller: ");

            for (int i = 0; i < vektor.Length; i++)//Jag använder en for-loop för att skriva ut varje element
            {
                if (vektor[i] == null)//Om användaren inte har lagt något i ryggsäcken, men vill se vad den innehåller, informerar programmet användaren om att ryggsäcken är tom
                {
                    Console.WriteLine("\n\tRyggsäcken är tom nu");
                    break;
                }
                else if (vektor[i] == "")//om det finns tom strängar i ryggsäcken, kommer programmet att informera 
                    Console.WriteLine(i + 1 + ") Det finns ingenting här");

                else if (vektor[i] != null && vektor[i] != "")//om det finns föremål i ryggsäcken (inte null eller mellanslag), kommer programmet att visa innehållet i ryggsäcken
                    Console.WriteLine((i + 1) + ") " + vektor[i]);
            }
            return vektor;
        }
        static string[] Sök(string[] vektor)
        {
            bool minBool = false;

            Console.WriteLine("\n\tVad vill du hitta i ryggsäcken? Skriv ett sökord: ");

            string sökord = Console.ReadLine();//Jag sparar sökordet som användaren har skrivit i en variabel [sökord]

            for (int i = 0; i < vektor.Length; i++)//Linjär sökning av innehållet i ryggsäcken
            {

                if (vektor[i] != null && vektor[i] != "" && sökord.ToUpper() == vektor[i].ToUpper())//Jag använder ToUpper för att användaren inte ska behöva tänka på stora eller små bokstäver.
                {
                    Console.WriteLine("\n\tSökningen lyckades! " + "Föremålet '" + sökord + "' som du letar efter finns på plats " + (i + 1));//Jag presenterar sökresultatet för användaren
                    minBool = true;
                    break;
                }
            }

            if (minBool == false)//Programmet informerar användaren om inget hittas efter jämförelse av sökordet med varje element eller om användaren har tryckt på mellanslagstangenten istället för att skriva in sökordet.
            {
                Console.WriteLine("\n\tInget sådant föremål hittades i ryggsäcken eller ryggsäcken är tom nu");
            }
            return vektor;  
        }
        static string[] RensaInnehållet (string[] vektor)
        {
            for (int i = 0; i < vektor.Length; i++)//Jag använder en for-loop för att rensa innehållet av varje element
            {
                vektor[i] = string.Empty;
            }
            Console.WriteLine("\n\tRyggsäcken är tom nu");
            return vektor;
        }

        static string SkrivUt(string text)//metoden som skriver ut en text
        {
            Console.WriteLine(text);
            return text; 
        
        }

        //Det är här programmet genomförs

        static void Main(string[] args)
        {

            bool b = true;//Jag skapar en variabel "b" som ska styra while-loopen - om variabelns värde är true körs loopen, om variabelns värde är false avslutas loopen
            string[] minVektor = new string[5];//Jag skapar en strängvektor som har fem element

            while (b)//Jag skapar en while-loop för att användaren alltid ska ha tillgång till programmenyn, utom när användaren vill avsluta programmet.
            {

                VisaMeny();

                bool lyckad = Int32.TryParse(Console.ReadLine(), out int tillvalen);//Här väljer användaren ett menval och jag lagrar detta värde i en variabel "tillvalen" och
                                                                                    //mitt program hanterar felaktig inmatning så att jag undviker att programmet kraschar
                if (lyckad)
                {

                    switch (tillvalen)//Jag skapar en switch-sats för att användaren kan använda programmenyn
                    {
                        case 1://det är menyval 1, där användaren kan tilldela ett strängvärde till varje element. 

                            minVektor = LäggTill();
                            break;

                        case 2://det är menyval 2, där användaren kan skriva ut varje element.

                            VisaInnehållet(minVektor);
                            break;

                        case 3://det är menyval 3, där användaren kan skriva ett sökord, som jämförs med varje element. Om sökningen lyckas ska de få ett meddelande. Använd en for-loop.

                            Sök(minVektor);
                            break;

                        case 4://det är menyalternativ 4, där användaren kan rensa innehållet av ryggsäcken
                            
                            RensaInnehållet(minVektor);
                            break;

                        case 5://det är menyval 5, där ska programmet avslutas
                            b = false;
                            break;

                        default://detta beskriver vad programmet ska göra om användaren väljer en punkt som inte finns i programmenyn
                            SkrivUt("\n\tDu måste välja menyalternativ 1-5");
                            break;
                    }
                }
                else {
                    SkrivUt("\n\tEndast siffrorna 1-5 kan användas för att välja ett menyval");
                }
            }
        }
    }
}