using System;
using System.Collections.Generic;

public class Program
{
    List<Ant> Anthill = new List<Ant>();

    static void Main()
    {
        Program p = new Program();
        p.intro();
    }

    /*
     * Robin:
     * Varför har denna metod liten bokstav?
     */
    void intro()
    {
        Console.WriteLine("Hello and welcome to the anthill!");
        Console.WriteLine("\nFor a list of commands type 'help'");
        while (true)
        {
            string userInput = Console.ReadLine().ToLower();
            if (userInput == "help")
            {
                Console.WriteLine("The available commands are: \n add \n remove \n list  \n search  \n count \n quit");
            }
            else if (userInput == "add")
            {
                NameAndLegs();
            }
            else if (userInput == "remove")
            {
                RemoveTheAnt();
            }
            else if (userInput == "list")
            {
                ListOfAnts();
            }
            else if (userInput == "search")
            {
                
                SearchAnt();
            }
            else if (userInput == "count")
            {
                CountAnts();
            }
            else if (userInput == "quit")
            {
                break;
            }
        }
    }

    public void NameAndLegs()
    {
        Ant A = new Ant();
        string SetName = NameAdd();
        int SetLegs = LegsAdd();

        string VersalAntName = SetName[0].ToString().ToUpper() + SetName.Substring(1);
        Console.WriteLine(VersalAntName + " that have " + SetLegs + "" + " Legs have been added");
        A.NameForAnt(SetName);
        A.LegsForAnt(SetLegs);
        Anthill.Add(A);
    }

    string NameAdd()
    {
        string SetName;
        while (true)
        {
            Console.WriteLine("Write in the name that you want to add \nThe name can't be longer than 10 letters");
            SetName = Console.ReadLine().ToLower();
            if (SetName.Length >= 10)

            {
                Console.WriteLine("The name should be less then 10 letters");
            }

            else
            {
                if (Anthill.Count > 0)
                {
                    bool NameCheck = true;
                    foreach (Ant A in Anthill)
                    {
                        if (SetName == A.Name)
                        {
                            Console.WriteLine("There is already an ant with that name");
                            NameCheck = false;
                        }
                    }

                    if (NameCheck == false)
                    {
                        continue;
                    }

                    else
                    {
                        string VersalAntName = SetName[0].ToString().ToUpper() + SetName.Substring(1);
                        Console.WriteLine(VersalAntName + " Has been created");
                        return SetName;
                    }
                }
                /*
                 * Robin:
                 * ojämn indentering.
                 */
            if (Anthill.Count <= 0)
            {
                    string VersalAntName = SetName[0].ToString().ToUpper() + SetName.Substring(1);
                    Console.WriteLine(VersalAntName + " Has been created");
                    return SetName;
            }
            }
        }
    }

    int LegsAdd()
    {
        int SetLegs;
        while (true)

        {
            try
            {
                Console.WriteLine(" \n How many legs would you like?");
                SetLegs = int.Parse(Console.ReadLine());

                if (SetLegs >= 0 & SetLegs <= 6)
                {
                    return SetLegs;
                }
                return SetLegs;
            }
            catch
            {

            }
        }

    }

    void RemoveTheAnt()
    {
        if (Anthill.Count <= 0)
        {
            Console.WriteLine("There is not a single ant to kill");
        } //when you remove the ant the first thing that you habe to check is that so it is an ant.
        else if (Anthill.Count > 0) //You will not be able to find any ant if you don't search for legs > 0 .
        {
            /*
             * Robin:
             * Man hade kunnat skippa boolen här, och i stället sätta en return inne i 
             * if(AntToRemove == A.Name). Då så behöver du inte göra NotFound == false
             * kollen sen.
             */
            bool NotFound = false;
            Console.WriteLine("Whats the name of the poor ant");
            string AntToRemove = Console.ReadLine().ToLower();
            foreach (Ant A in Anthill) //searches again with foreach.
            {
                if (AntToRemove == A.Name)
                {
                    Anthill.Remove(A);
                    NotFound = true;
                    Console.WriteLine("The ant has been removed");
                    break;
                }
            }
            if (NotFound == false) //if it can't find any ant then it is impossible to remove one.
            {
                Console.WriteLine("No ant with that name");
            }
        }
    }

    void ListOfAnts()
    {
        if (Anthill.Count <= 0)
        {
            Console.WriteLine("There are no ants in the list");
        }

        else if (Anthill.Count > 0)
        {
            foreach (Ant A in Anthill)
            {
                string VersalAntName = A.Name[0].ToString().ToUpper() + A.Name.Substring(1);
                Console.WriteLine("There is an ant called " + VersalAntName + " with " + A.Legs + " legs.");
            }

        }
    }
    
    void SearchAnt()
    {
        Console.WriteLine("You may find the ant be either trying to count it legs or guessing its name.\nHint!!!! Type legs or name.");
        string FindAnt = Console.ReadLine().ToLower();
        //Check so that there is ant ant before you search.
        if(FindAnt == "legs")
        {
            SearchByLegs();
        }
        else if(FindAnt == "name")
        {
            SearchByName();
        }
    }
    void SearchByName()
    {

        Console.WriteLine("Whats the name of the ant");
        string FindAntByName = Console.ReadLine().ToLower();
        /*
         * Robin:
         * Samma här kunde man ha optimerat genom att sätta en return inne i foreach-
         * loopen. Soeciellt med tanke på att det inte ska förekomma flera myror med 
         * samma namn.
         */
        bool Ant = true;
        foreach (Ant A in Anthill) //This is to check for ants it explains itself (foreach).
        {
            if(A.Name == FindAntByName)
            {
                string VersalAntName = A.Name[0].ToString().ToUpper() + A.Name.Substring(1);
                Console.WriteLine("There is a ant called " + VersalAntName + " with " + A.Legs + " legs"); //when it finds the ant it then prints out name and legs.
                Ant = false;
            }
        }
        if (Ant == true)
        {
            Console.WriteLine("No ant called that!"); //If the input writes a name then it will tell that there is no ant with that name.
        }
    }

    void SearchByLegs()
    {
        bool Ant = true;
        Console.WriteLine("How many legs does the ant have?");
        /*
         * Jag skulle så gäna velat se att du använde AddLegs() metoden här för
         * att undvika upprepad kod! 
         */
        try
        {
            int FindByLegs = int.Parse(Console.ReadLine()); //It makes it so that it goes from a string to a number.
            if (FindByLegs <= 6 & FindByLegs >= 0) 
            {
                foreach (Ant A in Anthill) //this is where it search for every leg so that it can find the ant by searching for it's legs.
                {
                    if (FindByLegs == A.Legs)
                    {
                        string NameWithLegs = A.Name[0].ToString().ToUpper() + A.Name.Substring(1).ToLower();
                        Console.WriteLine(" Ant named " + NameWithLegs + " got " +  A.Legs + " legs"); //same as for searchfor name as the input has to know if he found his ant or not.
                        Ant = false; 
                    }
                }
                if (Ant == true)
                {
                    Console.WriteLine(" No ant has that amount of legs"); //If the input searches for legs that no ant have.
                }
            }
      
        }
        catch
        {

        }
    }

    void CountAnts()
    {
        Console.WriteLine(Anthill.Count);
    }
    
}
class Ant
{
    public string Name;
    public int Legs;
    /*
     * Robin:
     * Varför finns de här 2 metoderna om variablerna ändå är public. jag skulle
     * föredragit om variablerna var private, och du hade get metoder och en 
     * konstruktor.
     */
    public void NameForAnt(string SetName)
    {
        Name = SetName;
    }
    public void LegsForAnt(int SetLegs)
    {
        Legs = SetLegs;

    }
}

/*
 * Robin:
 * Bra jobbat! Du har en tydlig och överlag konsekvent kodningsstil, med bra beskrivande 
 * namngivning. Det är några ställen som störde t.ex. så var det inte helt konsekvent med 
 * inledande stor bokstav på globala och lokala variabler etc.
 * 
 * Det finns några ställen där mindre optimeringar kunde utföras, men det är ingen stor
 * grej med tanke på uppgiftens storlek.
 * 
 * Koden är robust, och jag kunde inte hitta några uppenbara problem som kan leda till
 * att programmet kraschar.
 * 
 * Det verkar som att du programmerar rätt så självgående på lektionerna, vilket är
 * jättebra och kul att se!
 * 
 * Bra jobbat och fortsätt så här!
 */