//en lista över de bibliotek som jag använder
using System;
using System.Collections;
using System.Collections.Frozen;
using System.Collections.Generic;//vi behöver ett särskilt bibliotek för att arbeta med listor.
using System.Drawing;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text.RegularExpressions;//Jag använder ett reguljärt uttryck för att söka efter inläggets titel
using System.Threading;//vid programavslut använder vi väntetid så att användaren får tid att läsa meddelandet

namespace ConsoleApp7
{
    class Program6//klassen innehåller inte instanser (objekt), utan endast innehåller statiska metoder
    {

        //==========================================================================METODER======================================================================================
        //********************För menyval 1-6 har jag skrivit metoder för att tydliggöra vad som händer när en användare väljer ett menyval**************************************
        //=======================================================================================================================================================================
        static List<string[]> SkrivInlägg(List<string[]> blog, string[] inlägg)//som parametrar tar metoden emot en lista och en vektor, där metoden kommer att skriva de data som användaren anger

        {

            Console.WriteLine("\n\tSkriv en titel för din blogg");
            inlägg[0] = Console.ReadLine();
            Console.WriteLine("\n\tVad vill du säga? Skapa inlägg");
            inlägg[1] = Console.ReadLine();
            inlägg[2] = Convert.ToString(blog.Count + 1);//Jag vill tildälla id till varje inlägg
            inlägg[3] = Convert.ToString(DateTime.Now);//När jag skapar ett inlägg registrerar jag automatiskt tiden när det skapades, senare kommer användaren att kunna ändra tiden

            blog.Add(inlägg);//Jag lägger till vektorns element i listan 
            Console.WriteLine("\n\tDitt inlägg har sparats!");//programmet informerar användaren om att handlingen har utförts framgångsrikt, detta är viktigt för att underlätta arbetet med programmet

            return blog;//Metoden skickar tillbaka List<string[]> blog - en lista som innehåller vektorer. Listan är vår blogg, vektorerna är blogginlägg



        }

        static string[] VisaBlogInlägg(List<string[]> blog, string[] inlägg)//som parametrar tar metoden emot en lista och en vektor, där användaren har skrivit titeln och texten till sitt inlägg
        {
            if (blog.Count > 0)//Vi måste veta om listan är tom för att kunna informera en användaren om det
            {
                //---------------------------------------------FOR LOOP-------------------------------------------------------
                /* for (int i = 0; i < blog.Count; i++)
                 {
                     Console.WriteLine("\n\t----------------------------------------------------");
                     Console.WriteLine("\n\tID: " + blog[i][2]);
                     Console.WriteLine("\tInlägg skapades: " + blog[i][3]);
                     Console.WriteLine("\n\t\t\t\tTiteln: " + blog[i][0]);
                     Console.WriteLine("\n\t" + blog[i][1]);

                 }*/

                //-------------------------------------------FOREACH LOOP-----------------------------------------------------
                foreach (string[] item in blog)
                {
                    Console.WriteLine("\n\t----------------------------------------------------");
                    Console.WriteLine("\n\tID: " + item[2]);
                    Console.WriteLine("\t" + item[3]);//visa datum och tid
                    Console.WriteLine("\n\t\t\t\tTiteln: " + item[0]);
                    Console.WriteLine("\n\t" + item[1]);
                    Console.WriteLine("\n\t----------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("\n\tDet finns inga sparade inlägg!");/*om vi inte ger användaren den här informationen 
                                                                         * kommer de att tro att det är något fel med programmet, 
                                                                         * eftersom programmet ska visa användaren menyn om igen istället för att 
                                                                         * visa bloggens innehåll som inte finns*/
            }
            return inlägg;/*Metoden skickar tillbaka string[] inlägg - en vektor 
                           * som innehåller strängar med information om 
                           * titel, text, id och tidpunkt av inlägget*/

        }
        
            static string[] AllaTitlar(List<string[]> blog)//För att göra en jämförelse mellan ett sökord och varje inläggs titel behöver jag ha alla titlar som en vektor
        {
            string[] titlar = new string[blog.Count];//Jag vet inte det exakta antalet titlar,
                                                     //därför vet jag inte hur många inlägg en användare kommer att skapa,
                                                     //men i stället för ett heltal kan jag ange blog.Count
                                                     //för att skapa en vektor med det antal element som jag behöver

            int räknare = 0;//Jag behöver en räknare för att ange ett index för ett element i vektorn [titlar]

            foreach (string[] item in blog)//
            {

                titlar[räknare] = item[0];
                //Console.WriteLine(räknare + " " + titlar[räknare]);//Jag använde den här raden för testning
                räknare++;
            }

            /*for (int i = 0; i < titlar.Length; i++)//Om man vill använda den inbyggda räknaren kan man använda for-loopen
            {
                titlar[i] = blog[i][0];
                Console.WriteLine(i + " " + titlar[i]);
            }*/
            return titlar;//Metoden skickar tillbaka string[] titlar - en vektor som innehåller strängar med information om varje titel
        }

        static string[] AllaID(List<string[]> blog)//För att ta bort eller redigera ett element med bestämd id behöver jag ha alla id som en vektor
        {
            string[] identifikationer = new string[blog.Count];
            int räknare = 0;

            foreach (string[] item in blog)
            {

                identifikationer[räknare] = item[2];
                //Console.WriteLine(räknare + " " + identifikationer[räknare]);//Jag använde den här raden för testning
                räknare++;
            }
            return identifikationer;//Metoden skickar tillbaka string[] identifikationer - en vektor som innehåller strängar med information om varje id
        }

        static void TaBortInlägg(List<string[]> blog)//den här metoden är tom, den returnerar inget värde, 
                                                                      //den utför bara en handling att ta bort blogginlägget med det angivna id
        {
            if (blog.Count > 0)//programvaran omedelbart meddelar användaren om bloggen är tom, 
                               //för att undvika handlingar (ange id) som ändå inte kommer att leda till önskat resultat (ta bort inlägg) eftersom bloggen är tom
            {
                Console.WriteLine("\n\tAnge ID för det inlägg som du vill ta bort");
                if (!int.TryParse(Console.ReadLine(), out int id))//Jag kontrollerar att användaren har angett ett heltal som id för att undvika en programkrasch
                {
                    Console.WriteLine("\n\tEndast heltal accepteras som ID");
                    return;//Jag avslutar metoden, annars kommer användaren att få 2 meddelanden "Endast heltal accepteras som ID" och "Det angivna ID finns inte"
                }

                bool minBool = false;//Jag kontrollerar if-satsen med denna variabel
                string inläggID = Convert.ToString(id);//Jag sparade id som int, eftersom det var lättare att kontrollera att användaren angav korrekta data, 
                                                       //men i vektorn lagras ID som en sträng, så jag måste konvertera int till en sträng nu

                for (int i = 0; i < blog.Count; i++)//loop söker efter id i vektorn med alla id
                {

                    if (inläggID == blog[i][2])//om id hittas, kommer elementet med detta id att tas bort
                    {
                        Console.WriteLine("\n\tInlägget med ID " + id + " har tagits bort");
                        blog.RemoveAt(i);//Jag använder elements index för att ta bort elementet, programmet känner till detta index eftersom det är kopplat till id i vektorn med alla id
                        minBool = true;//Om elementet hittas programmet går inte vidare till nästa "if"
                        break;//Om elementet hittas avslutar jag loopen
                    }/*Jag kan inte använda "else" för att meddela användaren att "Det angivna ID finns inte" 
                      * eftersom "else" kommer att vara inuti loopen, och varje gång loopen körs kommer användaren att få meddelandet att "Det angivna ID finns inte" 
                      * tills det angivna ID hittas, vilket kommer att förvirra användaren.*/
                }

                if (minBool == false)//Om elementet inte hittas informerar jag användaren om detta
                {
                    Console.WriteLine("\n\tDet angivna ID finns inte");
                }
            }
            else
            {
                Console.WriteLine("\n\tDet finns inga sparade inlägg!");
            }

        }

        static void RedigeraDateTime(List<string[]> blog)//den här metoden är tom, den returnerar inget värde, 
                                                                          //den utför bara en handling att redigera blogginlägget med det angivna id
        {
            if (blog.Count > 0)//programvaran omedelbart meddelar användaren om bloggen är tom, 
                               //för att undvika handlingar (ange id) som ändå inte kommer att leda till önskat resultat (redigera inlägg) eftersom bloggen är tom
            {
                Console.WriteLine("\n\tAnge ID för det inlägg som du vill ändra");
                if (!int.TryParse(Console.ReadLine(), out int id))//Jag kontrollerar att användaren har angett ett heltal som id för att undvika en programkrasch
                {
                    Console.WriteLine("\n\tEndast heltal accepteras som ID");
                    return;
                }

                bool minBool = false;//Jag kontrollerar if-satsen med denna variabel
                string inläggID = Convert.ToString(id);

                for (int i = 0; i < blog.Count; i++)
                {

                    if (inläggID == blog[i][2])
                    {
                        Console.WriteLine("\n\tSkriv en ny titel: ");
                        blog[id-1][0] = Console.ReadLine();
                        Console.WriteLine("\n\tSkriva ny text: ");
                        blog[id - 1][1] = Console.ReadLine();
                        Console.WriteLine("\n\tÄndra datum och tid DD/MM/ÅR TT:MM:SS: ");//Jag tillåter bara användaren att ändra datumet, 
                                                                                         //så att jag kan kontrollera sorteringen efter datum senare
                        if (!DateTime.TryParse(Console.ReadLine(), out DateTime användarensDateTime))//Jag sparar DateTime som användaren har skrivit i en variabel [användarensDateTime]
                        {
                            Console.WriteLine("\n\tAnge korrekt datum- och tidsformat: DD/MM/ÅR TT:MM:SS!");//För sortering behöver jag datumet i some DateTime datatyp, inte sträng,
                                                                                                            //så det är bättre att kontrollera rätt datatyp direkt
                            return;//Avsluta metoden om ett ogiltigt värde anges
                        }
                        
                        blog[i][3] = Convert.ToString(användarensDateTime);//för att spara datumet i en List<string[]> blog med vektorer måste jag konvertera DateTime till en string
                        Console.WriteLine("\n\tDitt inlägg har ändrats!");
                        minBool = true;
                        break;
                    }
                }

                if (minBool == false)
                {
                    Console.WriteLine("\n\tDet angivna ID finns inte");
                }
            }
            else
            {
                Console.WriteLine("\n\tDet finns inga sparade inlägg!");
            }

        }

        static void LinjalSökning(List<string[]> blog)//En jämförelse mellan ett sökord och varje inläggs titel
        {
            bool minBool = false;

            Console.WriteLine("\n\tFör att söka inlägg på titel skriv ett sökord: ");

            string sökord = ".*" + Console.ReadLine() + ".*";//Jag sparar sökordet som användaren har skrivit i en variabel [sökord]
            //.*sökord.* Denna mall kommer att söka efter ordet "sökord" var som helst i strängen
            //.* - motsvarar vilket antal tecken som helst (inklusive nolltecken)

            for (int i = 0; i < blog.Count; i++)//Linjär sökning av inlägg i bloggen efter titel
            {

                /*if (vektor[i] != null && vektor[i] != "" && sökord.ToLower() == vektor[i].ToLower())//Jag använder ToLower() för att användaren inte ska behöva tänka på stora eller små bokstäver.
                {
                    Console.WriteLine("\n\tSökningen lyckades! \"" + sökord + "\" finns i inlägg med titeln " + vektor[i]);//Jag presenterar sökresultatet för användaren
                    minBool = true;
                    break;
                }*/
                
                if (blog[i][0] != "" && Regex.IsMatch(blog[i][0], sökord, RegexOptions.IgnoreCase))
                /*Jag kan inte jämföra en sträng som innehåller ett reguljärt uttryck (t.ex., .*fredag.*), 
                 * med vektors element med hjälp av operatorn ==. Detta fungerar inte eftersom strängen ".*fredag.*" inte är lika med (==) strängen "Fredag1", till exempel. 
                 * Jag måste använda en metod Regex.IsMatch() för att jämföra en sträng med ett reguljärt uttryck*/
                {
                    Console.WriteLine("\n\tDet finns inlägg med titeln \"" + blog[i][0] + "\"");//Jag presenterar sökresultatet för användaren
                    Console.WriteLine("\n\t----------------------------------------------------");
                    Console.WriteLine("\n\tID: " + blog[i][2]);
                    Console.WriteLine("\t" + blog[i][3]);
                    Console.WriteLine("\n\t\t\t\tTiteln: " + blog[i][0]);
                    Console.WriteLine("\n\t" + blog[i][1]);
                    Console.WriteLine("\n\t----------------------------------------------------");
                    minBool = true;
                    continue;
                }
            }

            if (minBool == false)//Programmet informerar användaren om inget hittas efter jämförelse av sökordet med varje element

            {
                Console.WriteLine("\n\tInget sådant hittades i bloggen");
            }
        }

        static void BinärSökning(List<string[]> blog)//Sökningsalgoritm - att sortera efter ID
        {
                Console.WriteLine("\n\tAnge ID för att söka inlägg: ");

                //Jag använder TryParse att undvika programkrasch om användaren inmatar något annat än ett heltal 
                if (!int.TryParse(Console.ReadLine(), out int key))//Jag sparar en siffra (id) som användaren har skrivit i en variabel [key]. [key] är ett id som vi söker
            {
                    Console.WriteLine("\n\tAnge ett heltal som ID!");
                    return;//Avsluta metoden om ett ogiltigt värde anges
                }
            //********************************************************************inuti detta stycke används en kopia av listan***********************************************************************//

            //==================================================================================Selection sort===================================================================
            //===================================================================================================================================================================
            List<string[]> sortedBlog = new List<string[]>(blog);// Skapa en kopia av listan
                //Jag sorterar kopia av listan, eftersom binär sökning kräver att listan är sorterad
                for (int i = 0; i < sortedBlog.Count - 1; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < sortedBlog.Count; j++)//Jag letar upp det minsta elementet i hela listan med alla id
                    {
                        if (string.Compare(sortedBlog[j][2], sortedBlog[minIndex][2], StringComparison.Ordinal) < 0)//Jag använder string.Compare() för att se vilken id som är störst - den till höger eller den till vänster

                    {
                            minIndex = j;//på det här sättet jag hittar indexet för elementet med det minsta id
                    }
                    }

                    if (minIndex != i) // om det första elementet inte redan är det minsta elementet
                    {
                        // Jag bytar plats på det första elementet och det minsta elementet 
                        string[] temp = sortedBlog[i];
                        sortedBlog[i] = sortedBlog[minIndex];
                        sortedBlog[minIndex] = temp;
                    }
            }//avsluta Selection sort

            //===========================================================================Binär sökning===========================================================================================
            //===================================================================================================================================================================================
                int first = 0;//det första indexet i den del av listan som vi söker i
                int last = sortedBlog.Count - 1;//det sista indexet i den del av listan som vi söker i

            while (first <= last)//en lista där index för första elementet är högre än index för sista elementet är ingen lista alls
            {
                int mid = (first + last) /2;//algoritmen delar upp listan i 2 delar till dess att den har hittat rätt. [mid] är mitten mellan det första indexet och det sista indexet
                if (key > Convert.ToInt32(sortedBlog[mid][2]))//sökta värdet ligger på övre delen av den aktuella listan
                {
                    first = mid + 1;
                }
                else if (key < Convert.ToInt32(sortedBlog[mid][2]))//sökta värdet ligger på undre delen av den aktuella listan
                {
                    last = mid - 1;
                }
                else//värdet [key] (det angivna id) är lika med värdet på talet vid index [mid] - presentera resultat av sökning efter id till användaren
                {
                        Console.WriteLine("\n\tEtt inlägg med ID " + key + " finns i bloggen: ");
                        Console.WriteLine("\n\t----------------------------------------------------");
                        Console.WriteLine("\n\tID: " + sortedBlog[mid][2]);
                        Console.WriteLine("\t" + sortedBlog[mid][3]);
                        Console.WriteLine("\n\t\t\t\tTiteln: " + sortedBlog[mid][0]);
                        Console.WriteLine("\n\t" + sortedBlog[mid][1]);
                        Console.WriteLine("\n\t----------------------------------------------------");
                        return; //Avsluta metoden för att undvika en oändlig while-loopen
                    }
            }//avsluta Binär sökning
             //********************************************stycke där används en kopia av listan är slut***********************************************************************//

            Console.WriteLine("\n\tInlägg med ID " + key + " finns inte i bloggen");//om den sökta id inte finns i vektorn
        }

        static List<string[]> BubbleSort(List<string[]> blog)//Sorteringsalgoritm 
        {
            List<string[]> list = blog;//Skapa listan
            int max = list.Count - 1;
            //Den yttre loopen, går genom hela listan
            for (int i = 0; i < max; i++)
            {
                //Den ingre loopen, går genom element för element
                int nrLeft = max - i;//hur många par av element som inte redan är färdigsorterade
                for (int j = 0; j < nrLeft; j++)
                {
                    DateTime dt0 = Convert.ToDateTime(blog[j][3]);//Om jag sorterar datum som lagras som strängar får jag fel resultat
                    DateTime dt1 = Convert.ToDateTime(blog[j + 1][3]);//därför konverterar jag från en sträng till DateTime
                    if (dt0.CompareTo(dt1) > 0)//jämför elementen: om datumet till vänster är högre än datumet till höger, ska de byta plats
                    {
                        //byt plats
                        string[] temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }

                }
            }
            Console.WriteLine("\n\tVi har sorterat dina inlägg efter datum.\n\tAtt titta på alla blog inlägg välj [2] från menyval");
            return list;//metoden skickar tillbaka en sorterad lista List<string[]> blog som vi har angett som parameter
        }

        static void SelectionSort(List<string[]> blog)//Jag sorterar titlar alfabetiskt genom CompareTo-metoden
        {
            
                for (int i = 0; i < blog.Count - 1; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < blog.Count; j++)//Jag letar upp ett index av det minsta elementet i hela listan med alla titlar
                    {
                        if (string.Compare(blog[j][0], blog[minIndex][0], StringComparison.OrdinalIgnoreCase) < 0)//Jag jämförar blog[j][0] med blog[minIndex][0].
                                                                                                                  //t.ex. blog[1][0] med blog[0][0]
                                                                                                                  //d.v.s. titeln av andra element av listan med
                                                                                                                  //titeln av första element av samma lista
                                                                                                                  //om andra titeln föregår första titeln
                                                                                                                  //fortsätter vi att jämföra elementens titlar
                                                                                                                  //tills villkoret inte längre är sant,
                                                                                                                  //då byter vi ut elementen, vilket koden nedan gör

                        /*StringComparison.OrdinalIgnoreCase compare strings using
                          ordinal (binary) sort rules and
                          ignoring the case of the strings being compared.
                          When you call a string comparison method you should always call
                          an overload that includes a parameter of type StringComparison
                          so that you can specify the type of comparison that the method performs*/
                        {
                            minIndex = j;
                        }
                    }

                    if (minIndex != i)
                    {
                        // Jag bytar plats på det första elementet och det minsta elementet (förutsatt att det första elementet inte redan är det minsta) 
                        string[] temp = blog[i];
                        blog[i] = blog[minIndex];
                        blog[minIndex] = temp;
                    }
                }
                Console.WriteLine("\n\tVi har sorterat dina inlägg i alfabetisk ordning efter titel.\n\tAtt titta på alla blog inlägg välj [2] från menyval");

        }



            //==========================================================================PROGRAM====================================================================================
            //=====================================================================================================================================================================

            static void Main()//Det är här programmet genomförs
        {
                List<string[]> minBlog = new List<string[]>(); //Jag skriver en lista [minBlog] som innehåller vektorer string[]
                                                               //Man kan inte deklarera string[] minInlägg = new string[4]; utan while-loop, annars sparar man samma vektor om och om igen

            Console.WriteLine("\n\tVälkommen till vår blogg!");

                bool kör = true;//villkor för att menyn ska köras
                while (kör)//För att användaren ska ständigt kunna återvända till menyn behöver vi en while-loop
            {
                /*Varje element i vektorn [minInlägg] är en sträng, eftersom en vektor bara kan innehålla element av en datatyp 
                 * I vårt fall är enklast att använda datatypen "string". 
                 * Vid behov kan vi konvertera en sträng till en annan datatyp, t.ex. "int" eller "DateTime". 
                 * Vi kan också utföra den omvända konverteringen
                 *Det är viktigt att placera vektorn string[] minInlägg inuti loopen så att alla vektorer sparas i listan - inte samma vektor om och om igen */
                string[] minInlägg = new string[4];// vektorn innehåller 4 element: [0] titeln, [1] inlägg, [2] id, [3] tid

                Console.WriteLine("\n\t[1] Skriv nytt inlägg i bloggen\n" +//Programmet visar menyn för användaren
                    "\t[2] Visa alla blog inlägg\n" +
                    "\t[3] Redigera blog inlägg\n" +
                    "\t[4] Ta bort blog inlägg\n" +
                    "\t[5] Sök inläg i bloggen\n" +
                    "\t[6] Sortera blog inlägg\n" +
                    "\t[7] Avsluta programmet");
                    Console.Write("\tVälj: ");
                    int val;//i den här variabeln lagrar jag användarens menyval

                    if (!int.TryParse(Console.ReadLine(), out val))//Jag kontrollerar att användaren har angett ett heltal för att undvika en programkrasch
                    {   //man kan göra ingenting, för om konverteringen misslyckas kommer [val] automatiskt att bli 0 och "default" kommer att väljas från menyn 
                        //eller man kan göra nedanstående
                        //Console.WriteLine("\n\tVälj 1-7 från menyn.");
                        //continue;
                    }

                    switch (val)//Jag använder en switchstruktur för att få menyn att fungera
                {
                        case 1://[1] Skriv nytt inlägg i bloggen 

                            SkrivInlägg(minBlog, minInlägg);
                            break;

                        case 2://[2] Skriv ut alla blog inlägg

                            VisaBlogInlägg(minBlog, minInlägg);
                            break;

                        case 3://Redigera blog inlägg - jag får redigera bara datum

                            RedigeraDateTime(minBlog);
                            break;

                        case 4://[4] Ta bort blog inlägg

                            TaBortInlägg(minBlog);
                            break;

                        case 5://[5] Sök inläg i bloggen efter titel eller efter id
                            if (minBlog.Count > 0)//programvaran omedelbart meddelar användaren om bloggen är tom, 
                                                  //för att undvika handlingar (att göra menyval)
                                                  //som ändå inte kommer att leda till önskat resultat (hitta inlägg) eftersom bloggen är tom
                                                  //Om man sorterar en tom lista med binärSökning kommer man att få ett IndexOutOfRangeException
                        {
                            Console.WriteLine("\n\tSkriv \"Titel\" om du vill söka efter titel\n\tSkriv \"ID\" om du vill söka efter ID");
                            bool menyValSök = true;//villkor för att menyn ska köras
      
                            while (menyValSök)//om användaren gör ett misstag kan han fortsätta att arbeta med den inre menyn utan att behöva gå tillbaka till den yttre menyn
                            {
                                string sökningVal = Console.ReadLine().ToLower();//Jag använder ToLower()
                                                                                 //så att användaren inte behöver tänka på hur man skriver menyvalet på rätt sätt

                                switch (sökningVal)
                                {
                                    case "id":
                                        BinärSökning(minBlog);
                                        menyValSök = false;//Jag avslutar loopen om id hittas.
                                        break;

                                    case "titel":
                                        //string[] titlar = AllaTitlar(minBlog);
                                        LinjalSökning(minBlog);
                                        menyValSök = false;//Jag avslutar loopen om sökordet hittas.
                                        break;

                                    default: 
                                        Console.WriteLine("\n\tVälj \"Titel\" eller \"ID\" från menyn.");
                                        break;
                                }
                            } //avsluta while

                        }
                        else
                            {
                                Console.WriteLine("\n\tDet finns inga sparade inlägg!");
                            }
                            break;

                        case 6://[6] Sortera inlägg efter titel eller datum
                        
                        if (minBlog.Count > 0)//programvaran omedelbart meddelar användaren om bloggen är tom, 
                                              //för att undvika handlingar (att göra menyval)
                                              //som ändå inte kommer att leda till önskat resultat (sortera inlägg) eftersom bloggen är tom
                                              
                        {

                            Console.WriteLine("\n\tSkriv \"Titel\" om du vill sortera efter en titel\n\tSkriv \"Datum\" om du vill sortera efter en datumet");
                            bool menyValSort = true;//villkor för att menyn ska köras
                            while (menyValSort)//om användaren gör ett misstag kan han fortsätta att arbeta med den inre menyn utan att behöva gå tillbaka till den yttre menyn
                            {
                                string sökningVal = Console.ReadLine().ToLower();//Jag använder ToLower()
                                                                                 //så att användaren inte behöver tänka på hur man skriver menyvalet på rätt sätt



                                switch (sökningVal)
                            {
                                case "datum":
                                    BubbleSort(minBlog);
                                        menyValSort = false;//Jag avslutar loopen efter sortering
                                        break;

                                case "titel":
                                    SelectionSort(minBlog);
                                        menyValSort = false;////Jag avslutar loopen efter sortering
                                        break;

                                default:
                                    Console.WriteLine("\n\tVälj \"Titel\" eller \"Datum\" från menyn.");
                                        
                                        break;
                            }
                            } //avsluta while
                        }
                        else
                        {
                            Console.WriteLine("\n\tDet finns inga sparade inlägg!");
                        }
                            break;

                        case 7:
                            Console.WriteLine("\n\tTack för att du använder vår blogg!");
                            Thread.Sleep(2000);//använder jag väntetid så att användaren får tid att läsa meddelandet
                            kör = false;//avsluta while-loop och programmet
                            break;

                        default:
                            Console.WriteLine("\n\tVälj 1-7 från menyn.");
                            break;
                    }
                }
            }
       }
    }
         
    

