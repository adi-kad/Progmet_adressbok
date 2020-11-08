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
            Console.WriteLine("Hjälpkommandon: ");
            Console.WriteLine("Skriv \"show\" för att se kontakter" +
                "\nSkriv \"add\" för att lägga till ny kontakt" +
                "\nSkriv \"delete\" för att ta bort kontakt" +
                "\nSkriv \"edit\" för att redigera kontaktinformation" +
                "\nSkriv \"save\" för att spara ändringar" +
                "\nSkriv \"exit\" för att avsluta programmet");
            do
            {
                Console.Write("> ");
                command = Console.ReadLine();
                Console.WriteLine($"command: {command}");

                string nameDisplay = "Name", adressDisplay = "Adress", phone = "Phone", email = "E-mail", listPosition = "Nr";
                if (command == "show")
                {
                    Console.WriteLine();
                    Console.WriteLine($"{listPosition,-10}{nameDisplay,-20}{adressDisplay,-20}{phone,-20}{email,-20}");

                    int listPos = 1;
                    foreach (Person person in adressBook)
                    {
                        Console.WriteLine($"{listPos,-10}{person.name,-20}{person.adress,-20}{person.telephone,-20}{person.email,-20}");
                        listPos++;
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
                    Console.WriteLine("Skriv \"save\" för att spara listan");

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
                    Console.WriteLine($"\n{listPosition,-10}{nameDisplay,-20}{adressDisplay,-20}{phone,-20}{email,-20}");
                    for (int i = 0; i < adressBook.Count(); i++)
                    {
                        int listPos = i + 1;
                        Console.WriteLine($"{listPos,-10}{adressBook[i].name,-20}{adressBook[i].adress,-20}{adressBook[i].telephone,-20}{adressBook[i].email}");
                    }
                    Console.WriteLine();
                    Console.Write("Ange nummer för kontakt som ska raderas från listan: ");
                    int inputNum;
                    int.TryParse(Console.ReadLine(), out inputNum);
                    for (int i = 0; i < adressBook.Count(); i++)
                    {
                        int listPos = i + 1;
                        if (listPos == inputNum)
                        {
                            Console.WriteLine($"{adressBook[i].name} togs bort från listan!");
                            adressBook.RemoveAt(i);
                            Console.WriteLine("Skriv \"save\" för att spara listan");
                        }
                    }
                }
                else if (command == "edit") 
                {
                    Console.WriteLine($"\n{listPosition,-10}{nameDisplay,-20}{adressDisplay,-20}{phone,-20}{email,-20}");

                    for (int i = 0; i < adressBook.Count(); i++)
                    {
                        int listPos = i + 1;
                        Console.WriteLine($"{listPos,-10}{adressBook[i].name,-20}{adressBook[i].adress,-20}{adressBook[i].telephone,-20}{adressBook[i].email}");
                    }
                    Console.WriteLine();
                    Console.Write("Ange nummer för kontakt som ska redigeras: ");
                    int inputNum;
                    int.TryParse(Console.ReadLine(), out inputNum);
                    for (int i = 0; i < adressBook.Count(); i++)
                    {
                        int listPos = i + 1;
                        if (listPos == inputNum)
                        {
                            Console.WriteLine($"{listPosition,-10}{nameDisplay,-20}{adressDisplay,-20}{phone,-20}{email,-20}");
                            Console.WriteLine($"{listPos,-10}{adressBook[i].name,-20}{adressBook[i].adress,-20}{adressBook[i].telephone,-20}{adressBook[i].email}");
                            Console.WriteLine("\nAnge nummer för det du vill ändra\n" +
                                "1. Namn   2. Adress   3. Telefonnummer   4. E-mail");
                            int choice;
                            int.TryParse(Console.ReadLine(), out choice);

                            switch (choice)
                            {
                                case 1:
                                    string oldName = adressBook[i].name;
                                    Console.Write("Ange nytt namn för denna kontakt: ");
                                    adressBook[i].name = Console.ReadLine();
                                    Console.WriteLine($"Kontakten bytte namn från {oldName} till {adressBook[i].name}");
                                    break;
                                case 2:
                                    string oldAdress = adressBook[i].adress;
                                    Console.Write("Ange ny adress för denna kontakt: ");
                                    adressBook[i].adress = Console.ReadLine();
                                    Console.WriteLine($"Kontakten bytte adress från {oldAdress} till {adressBook[i].adress}");
                                    break;
                                case 3:
                                    string oldNumber = adressBook[i].telephone;
                                    Console.Write("Ange nytt telefonnummer för denna kontakt: ");
                                    adressBook[i].telephone = Console.ReadLine();
                                    Console.WriteLine($"Kontakten bytte telefonnummer från {oldNumber} till {adressBook[i].telephone}");
                                    break;
                                case 4:
                                    string oldEmail = adressBook[i].email;
                                    Console.Write("Ange ny e-mail för denna kontakt: ");
                                    adressBook[i].email = Console.ReadLine();
                                    Console.WriteLine($"Kontakten bytte e-mail från {oldEmail} till {adressBook[i].email}");
                                    break;
                                default:
                                    break;
                            }
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
