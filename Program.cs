using System;
using static Program;

class Program
{
    public struct Person
    {
        public string Name;
        public string Number;

        public Person(string name, string number)
        {
            Name = name;
            Number = number;
        }
    }

    public static List<Person> people = new List<Person>();

    public static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------- 118 Menu -------------");
        Console.WriteLine(" 1- Add ");
        Console.WriteLine(" 2- Edit ");
        Console.WriteLine(" 3- Search");
        Console.WriteLine(" 4- Delete");
        Console.WriteLine(" 5- List");
        Console.WriteLine(" 6- Exit");
        Console.Write(" Choose An Option: ");
    }

    public static void AddPerson()
    {
        Console.Clear();
        Console.Write("give me a name : ");
        string name = Console.ReadLine();

        Console.Write("give me a number : ");
        string number = Console.ReadLine();

        people.Add(new Person(name, number));

    }

    public static void ShowPersonList()
    {
        Console.Clear();
        Console.WriteLine("================= List of People =================");


        foreach (Person person in people)
        {
            Console.WriteLine($"{people.IndexOf(person) + 1} - {person.Name} : {person.Number}");
        }


        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }

    public static void EditPerson()
    {
        Console.Clear();
        Console.Write("give me a name : ");
        string name = Console.ReadLine();
        bool found = false;
        int editedNodeNumber = 0;

        foreach (Person person in people)
        {
            if (person.Name == name)
            {
                editedNodeNumber = people.IndexOf(person);
                found = true;

            }
        }
        if (!found)
        {
            Console.WriteLine("name not found");
        }
        else
        {
            Console.Write("give me a name : ");
            string newName = Console.ReadLine();

            Console.Write("give me a number : ");
            string Newumber = Console.ReadLine();

            people[editedNodeNumber] = new Person(newName, Newumber);
            Console.WriteLine("Person Edited succesfully");
            Console.ReadKey();
            ;
        }
    }


    public static void SearchPerson()
    {
        Console.Clear();
        Console.Write("give me a name : ");
        string name = Console.ReadLine();
        bool found = false;

        foreach (Person person in people)
        {
            if (person.Name == name)
            {
                Console.WriteLine($"{people.IndexOf(person) + 1} - {person.Name} : {person.Number}");
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("name not found");
        }
        Console.ReadKey();
        ;
    }

    public static void DeletePerson()
    {
        Console.Clear();
        Console.Write("give me a name : ");
        string name = Console.ReadLine();
        bool found = false;
        int deletedNodeNumber = 0;

        foreach (Person person in people)
        {
            if (person.Name == name)
            {
                deletedNodeNumber = people.IndexOf(person);
                found = true;

            }
        }
        if (!found)
        {
            Console.WriteLine("name not found");
        }
        else
        {
            Console.Write("Are you sure ? (Y/N) ");
            string decision = Console.ReadLine();
            if (decision == "Y")
            {
                people.Remove(people[deletedNodeNumber]);
                Console.WriteLine("Person Deleted successfully");
            }
            else
            {
                Console.WriteLine("ok you ignored");
            }
        }
    }


    public static void Main()
    {
        int SelectedOperation;

        do
        {
            ShowMenu();
            string input = Console.ReadLine();

            if (!int.TryParse(input, out SelectedOperation))
            {
                SelectedOperation = 0;
            }

            switch (SelectedOperation)
            {
                case 1:
                    AddPerson();
                    break;
                case 2:

                    EditPerson();
                    break;
                case 3:
                    SearchPerson();

                    break;
                case 4:



                    Console.WriteLine("Delete function not implemented yet.");
                    Console.ReadKey();
                    break;



                case 5:
                    ShowPersonList();
                    break;


                case 6:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid option! Please try again.");
                    Console.ReadKey();
                    break;
            }

        } while (SelectedOperation != 6);
    }
}