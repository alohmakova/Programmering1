// See https://aka.ms/new-console-template for more information
using System;

namespace MyApp
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            /*Skriva ett program som hanterar inmatning och utskrift. 
              Programmet är en ryggsäck som styrs genom en meny. 
              Menyn visar tillvalen som finns för användaren.*/

            bool b = true;//Jag skapar en variabel "b" som ska styra while-loopen - om variabelns värde är true körs loopen, om variabelns värde är false avslutas loopen
            string föremål = "";//Jag skapar en variabel "föremål" som visar vad användaren lägger i ryggsäcken. 

            /*Man måste deklarera den här variabeln (string föremål = "";) utanför while-loopen 
             för att det ska vara möjligt att använda det värde som användaren tilldelade denna variabel i menyval 1 i andra menyval (till exempel i menyval 2). 
             Om deklarationen av variabeln flyttas in i while-loopen kommer variabeln "föremål" att tilldelas det värde som den tilldelades vid initieringen vid varje nytt menyval, 
            vilket betyder att värdet av variabeln "föremål" ska vara "" vid varje nytt menyval*/

            while (b)//Jag skapar en while-loop för att användaren alltid ska ha tillgång till programmenyn, utom när användaren vill avsluta programmet.
            {
                Console.WriteLine("Välkommen till ryggsäcken!");//detta är programmenyn, som består av 4 punkter
                Console.WriteLine("[1] Lägg till ett föremål");
                Console.WriteLine("[2] Skriv ut innehållet");
                Console.WriteLine("[3] Rensa innehållet");
                Console.WriteLine("[4] Avsluta");
                Console.Write("Välj: ");

                string tillvalen = Console.ReadLine();//Här väljer användaren ett menyalternativ och jag lagrar detta värde i en variabel "tillvalen"
                int nr = Convert.ToInt32(tillvalen);//Här konverterar jag ett värde av variabel "tillvalen" från en string till ett int, så att jag kan styra switch-satsen med det värdet

                switch (nr)//Jag skapar en switch-sats för att användaren kan använda programmenyn
                {
                    case 1://det är menyalternativ 1, där användaren kan lägga till ett föremål i ryggsäcken

                        Console.Write("Lägg till ett föremål: ");
                        föremål = Console.ReadLine();
                        break;

                    case 2://det är menyalternativ 2, där programmet skriver ut innehållet av ryggsäcken
                        Console.WriteLine("Ryggsäcken innehåller: " + föremål);
                        break;

                    case 3://det är menyalternativ 3, där användaren kan rensa innehållet av ryggsäcken
                        föremål = "";
                        Console.WriteLine("Ryggsäcken är tom nu");
                        break;

                    case 4://det är menyalternativ 4, där användaren kan avsluta programmet
                        b = false;
                        break;

                        default://detta beskriver vad programmet ska göra om användaren väljer en punkt som inte finns i programmenyn
                        Console.WriteLine("Du måste välja menyalternativ 1-4");
                        break;
                }//Switch kodblock slutas här
            }//While-loop kodblock slutas här
        }//Main-metoden kodblock slutas här
    }
}
    

