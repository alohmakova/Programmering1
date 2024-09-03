using System;//CS0246: The type or namespace name 'system' could not be found (are you missing a using directive or an assembly reference?): skriv System istället av system

namespace Uppgift_4
{
    class Program3
    {
        static void Main(string[] args)
        {
            bool spelaEnGångTill = true;
            /*Skapa en variabel [spelaEnGångTill] för att kontrollera att nytt speltal genereras 
             och om spelet ska fortsätta köras tills användaren vill avsluta spelet*/

            int val = 0;//Skapa en variabel [val] för att kontrollera om användaren vill fortsätta spelet eller inte


            while (spelaEnGångTill)//loop som gör det möjligt för att spela flera gånger
            {

                // Deklaration av variabler
                Random slumpat = new Random(); // skapar ett random objekt
                int speltal = slumpat.Next(1, 21); // anropar Next metoden för att skapa ett slumptal mellan 1 och 20
                /*Random.Next generates a random number whose value ranges from 0 to less than Int32.MaxValue 
                 To generate a random number within a different range (1-20), use the Random.Next(Int32, Int32)*/
                
                //Console.Write("speltal är " + speltal);//jag änvändade det att testa programmet lättare

            bool spela = true; // Variabel för att kontrollera om spelet ska fortsätta köras
            int antaletGissningar = 0;//Skapa en variabel [antaletGissningar] för att räkna antalet gissningar




                while (spela)//skriv spela istället av !spela att köra ett spel
            {
                Console.Write("\n\tGissa på ett tal mellan 1 och 20: ");
                Console.WriteLine("\n\tAntalet gissningar är " + antaletGissningar++);

                    bool lyckad = Int32.TryParse(Console.ReadLine(), out int tal);//TryParse undersöker om värdet vi försöker konvertera är en siffra.

                    /*TryParse är nödvändigt om användaren har angett ett värde som programmet inte kan bearbeta, t.ex. en sträng eller ett decimaltal.
                     Boolvärde visar om konverteringen lyckades*/

                    if (!lyckad)//om konverteringen misslyckas informerar programmet användaren att deras värde var inte ett heltal
                    {
                        Console.WriteLine("\n\t\tEndast siffror (heltal) kan användas i detta spel!");//Det var intressant att lära mig att även om konverteringen misslyckas kommer värdet 0 att sparas i variabeln [tal] 
                    }

                    else//om konverteringen lyckas kontrollerar programmet om användaren har gissat talet
                    {

                        if (tal < 1 || tal > 20)//Jag vill att användaren bara ska använda siffrorna mellan 1 och 20 för att spela
                        {
                            Console.WriteLine("\n\t\tEndast siffror mellan 1 och 20 kan användas i detta spel!");//annars kommer dem att få en meddelande att de har gjort ett misstag
                            continue;
                        }
                        else if (tal < speltal)//Det är inte bra att använda if-satsen 3 raka gånger.
                        /*När vi använder if-satsen 3 gånger i rad kontrollerar programmet alla 3 villkor, men det är onödigt och det gör programmet långsammare, 
                         om det sanna villkoret har redan hittats behöver vi inte kontrollera de andra villkoren, 
                        eftersom användarens [tal] till exempel inte kan vara både mindre än och lika med [speltal] samtidigt*/

                        {
                            Console.WriteLine("\tDet inmatade talet " + tal + " är för litet, försök igen.");
                            continue;//För att göra programmet snabbare kan vi använda nyckelord continue, då kommer programmet inte att gå till slutet av loopen, utan omedelbart starta en ny loop

                        }

                        else if (tal > speltal)
                        {
                            Console.WriteLine("\tDet inmatade talet " + tal + " är för stort, försök igen.");//Operatorn för konkatenering (+) saknas. Syntax error
                            continue;
                        }

                        else if (tal == speltal) //CS0029: Cannot implicitly convert type 'int' to 'bool'. Skriv == istället av = 
                        {//Vi måste visa att if-satsen börjar här. Vår struktur innehåller mer än en rad, eftersom måste vi markera ut ett kodblock med {}.
                            Console.WriteLine("\tGrattis, du gissade rätt!");
                            Console.WriteLine("\n\tAntalet gissningar är " + antaletGissningar++);//Visa antalet gissningar till användaren
                            spela = false;

                        }//Vi måste visa att if-satsen slutas här. Annars tycker programmet att kommando "spela = false;" är utanför kodblocket och utför kommandot ändå, även om [tal] är inte leka med speltal
                        
                    }                                                                          
                
            }
                do//Loopen fortsätter att fråga användaren om de vill fortsätta spelet eller inte om användaren har gjort ett ogiltigt menyval
                {
                Console.WriteLine("\tVill du spella en gång till? " + "\n\t\t\t\t [1] Ja " + "\n\t\t\t\t [2] Nej");

                    bool lyckadVal = Int32.TryParse(Console.ReadLine(), out val);//Spara användarens [val]. TryParse undersöker om värdet vi försöker konvertera är en siffra.

                    if (!lyckadVal)//om konverteringen misslyckas, då har användaren gjort ogiltigt val: inte heltal

                    {
                        Console.WriteLine("\n\tEndast siffror 1 eller 2 kan användas!");//Programmet informerar  användaren att endast siffror 1 eller 2 kan användas
                    }
                    else//om konverteringen lyckas kontrollerar programmet vilket val användaren har gjort
                    { 
                    
                    switch (val)
                {
                    case 1://användaren sa "ja" 
                        spela = false;//detta spel avslutas och ett nytt spel börjar, där man måste gissa ett nytt speltal
                        break;

                    case 2://användaren sa "nej" 
                         spelaEnGångTill = false;//Spelet är slut. Avsluta programmet
                         break;

                    default://användaren har gjort ett ogiltigt menyval: inte 1 eller 2

                         Console.WriteLine("\n\tDu kan välja bara Ja eller Nej");//Informera användaren att de gjort ett ogiltigt val. 
                         break;
                    }
                    }
                    
                }
                
                while (val != 1 && val != 2);//programmet kontrollerar om användaren vill fortsätta spelet eller inte här
            }
            
        }
    }
}
