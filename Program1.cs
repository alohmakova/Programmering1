using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hej! Skriv ditt förnamn: ");//Jag visar text "Hej! Skriv ditt förnamn: " i konsolfönstret
            string namn = Console.ReadLine(); //Jag läser in användarens förnamn och spara detta i variabel
            Console.WriteLine("Skriv ditt efternamn: ");//Jag visar text "Hej! Skriv ditt efternamn: " i konsolfönstret
            string efternamn = Console.ReadLine(); //Jag läser in användarens efternamn och spara detta i variabel
            Console.WriteLine("Trevligt att träffas, " + namn + " " + efternamn + "!"); //Jag hälsar användaren 
            Console.Write("Ange din ålder (hela antalet år, endast siffror accepteras): " );//Jag frågar användaren om ålder i år 
            int ålder = Convert.ToInt32(Console.ReadLine());//Jag sparar användarens ålder i en variabel med int datatyp
            int ålderAntaletDagar = ålder * 365;//Jag räknar ut antalet dagar personen har levt utifrån den angivna åldern (ålder multiplicerat med 365) 
            Console.WriteLine("Du har levt " + ålderAntaletDagar + " dagar");//Jag presenterar antalet dagar personen har levt
            //Tillägg:
            Console.WriteLine("När är din födelsedag, " + namn + "? Använd formatet DD/MM/ÅÅ");//Jag frågar användaren om datum för födelsedag
            DateTime födelsedag = DateTime.Parse(Console.ReadLine());
            DateTime nutid = DateTime.Now;
            TimeSpan antaletFödelsedagar = nutid - födelsedag;
            int antaletFödelsedagar1 = Convert.ToInt32(antaletFödelsedagar.Days/365);//Jag räknar ut antalet födelsedagar
            Console.WriteLine("Dit antal födelsedagar är : " + antaletFödelsedagar1); //Jag skriver ut antalet födelsedagar
            int dagar = Convert.ToInt32(antaletFödelsedagar.Days);
            int månader = Convert.ToInt32(antaletFödelsedagar.Days/12);
            int timmar = Convert.ToInt32(antaletFödelsedagar.TotalHours);
            Console.WriteLine("Du har levt " + dagar + " dagar, " + månader + " månader och " + timmar + " timmar");
            /*Jag skriver ut mer detaljerad data om användarens ålder: dagar, månader och timmar*/
            Console.ReadLine();
           
        }
    }
}
