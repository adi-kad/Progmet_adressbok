using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progmet_adressbok
{
    class Program
    {
        class Person
        {
            public string name = "", adress = "", telephone = "", email = "";
            public Person()
            {

            }
            public Person(string name, string adress, string telephone, string email)
            {
                this.name = name;
                this.adress = adress;
                this.telephone = telephone;
                this.email = email;
            }
        }

        static void Main(string[] args)
        {
            string filepath = @"C:\Users\Admin\adressbok.txt";
            List<string> lines = File.ReadAllLines(filepath).ToList();
            List<Person> adressBook = new List<Person>();
            string command = "";

            foreach (string line in lines)
            {
                string[] personInfo = line.Split(',');
                Person newPerson = new Person(personInfo[0], personInfo[1], personInfo[2], personInfo[3]);
                adressBook.Add(newPerson);
            }

            Console.WriteLine("Välkommen till adressboken\n");
            Console.WriteLine("Skriv \"show\" för att se kontakter\nSkriv \"add\" för att lägga till ny kontakt\nSkriv \"delete\" för att ta bort kontakt\nSkriv \"exit\" för att avsluta programmet");
            do
            {
                Console.Write("> ");
                command = Console.ReadLine();
                Console.WriteLine($"command: {command}");

                if (command == "show")
                {
                    string nameDisplay = "Name", adressDisplay = "Adress", phone = "Phone", email = "E-mail";
                    Console.WriteLine("Showing Contacts\n");
                    Console.WriteLine($"{nameDisplay,-20}{adressDisplay,-20}{phone,-20}{email,-20}");

                    foreach (Person person in adressBook)
                    {
                        Console.WriteLine($"{person.name,-20}{person.adress,-20}{person.telephone,-20}{person.email,-20}");                      
                    }
                    Console.WriteLine();
                }
                else if (command == "add")
                {
                    Person newPerson = new Person();

                    Console.WriteLine("Lägg till ny kontakt");
                    Console.Write("Ange namn: ");
                    newPerson.name = Console.ReadLine();
                    Console.Write("Ange adress: ");
                    newPerson.adress = Console.ReadLine();
                    Console.Write("Ange telefonnummer: ");
                    newPerson.telephone = Console.ReadLine();
                    Console.Write("Ange e-mail: ");
                    newPerson.email = Console.ReadLine();

                    adressBook.Add(newPerson);
                    Console.WriteLine("Ny kontakt tillagd!");

                }
                else if (command == "save")
                {
                    Console.WriteLine("Listan sparad och uppdaterad!");
                    StreamWriter writer = new StreamWriter(filepath);
                    foreach (Person person in adressBook)
                    {
                        writer.WriteLine($"{person.name},{person.adress},{person.telephone},{person.email}");
                    }
                    writer.Close();
                }
                else if (command == "delete")
                {
                    for (int i = 0; i < adressBook.Count(); i++)
                    {
                        int listPos = i + 1;
                        Console.WriteLine($"{listPos}. {adressBook[i].name}");
                    }

                    Console.Write("Ange nummer för den kontakt du vill ta bort: ");
                    int inputNum;
                    int.TryParse(Console.ReadLine(), out inputNum);
                    for (int i = 0; i < adressBook.Count(); i++)
                    {
                        int listPos = i + 1;
                        if (listPos == inputNum)
                        {
                            Console.WriteLine($"{adressBook[i].name} togs bort från listan!");
                            adressBook.RemoveAt(i);                          
                        }
                    }
                }
                else if (command == "exit")
                {
                    Console.WriteLine("Adjö!");
                }

            } while (command != "exit");

            Console.ReadKey();
        }
    }
}
