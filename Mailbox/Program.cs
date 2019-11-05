using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    class Program
    {
        private const int Width = 30;
        private const int Height = 10;

        static void Main()
        {
            //Main does not need to be unit tested.
            using var dataLoader = new DataLoader(File.Open("Mailboxes.json", FileMode.OpenOrCreate, FileAccess.ReadWrite));

            Mailboxes boxes = new Mailboxes(dataLoader.Load() ?? new List<Mailbox>(), Width, Height);

            while (true)
            {
                int selection;
                do
                {
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine(" 1. Add a new mailbox");
                    Console.WriteLine(" 2. List existing owners");
                    Console.WriteLine(" 3. Save changes");
                    Console.WriteLine(" 4. Show mailbox details");
                    Console.WriteLine(" 5. Quit");

                    if (!int.TryParse(Console.ReadLine(), out selection))
                    {
                        selection = 0;
                    }
                } while (selection == 0);

                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Enter the first name");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter the last name");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("What size?");
                        if (!Enum.TryParse(Console.ReadLine(), out Sizes size))
                        {
                            size = Sizes.Small;
                        }

                        if (AddNewMailbox(boxes, firstName, lastName, size) is Mailbox mailbox)
                        {
                            boxes.Add(mailbox);
                            Console.WriteLine("New mailbox added");
                        }
                        else
                        {
                            Console.WriteLine("No available location");
                        }

                        break;
                    case 2:
                        Console.WriteLine(GetOwnersDisplay(boxes));
                        break;
                    case 3:
                        dataLoader.Save(boxes);
                        Console.WriteLine("Saved");
                        break;
                    case 4:
                        Console.WriteLine("Enter box number as x,y");
                        string boxNumber = Console.ReadLine();
                        string[] parts = boxNumber.Split(',');
                        if (parts?.Length == 2 &&
                            int.TryParse(parts[0], out int x) &&
                            int.TryParse(parts[1], out int y))
                        {
                            Console.WriteLine(GetMailboxDetails(boxes, x, y));
                        }
                        else
                        {
                            Console.WriteLine("Invalid box number");
                        }
                        break;
                    default:
                        return;
                }
            }
        }

        public static string GetOwnersDisplay(Mailboxes mailboxes)
        {
            if(mailboxes is null)
            {
                throw new ArgumentNullException(nameof(mailboxes));
            }
            if (mailboxes.Count == 0)
            {
                return "No Mailboxes are owned at this time.";
            }

            string owners = "";

            foreach (Mailbox mb in mailboxes)
            {
                owners += (mb.ToString() + "\n");
            }

            return owners;
        }

        public static string GetMailboxDetails(Mailboxes mailboxes, int x, int y)
        {
            if(mailboxes is null)
            {
                throw new ArgumentNullException(nameof(mailboxes));
            }
            if (x < 0 || x > Width)
            {
                throw new ArgumentOutOfRangeException(nameof(x));
            }
            if(y < 0 || y > Height)
            {
                throw new ArgumentOutOfRangeException(nameof(y));
            }

            string details = "";

            foreach(Mailbox mb in mailboxes)
            {
                if(mb.Location == (x, y))
                {
                    return details += mb.ToString();
                }
            }

            return "Nobody is using this Mailbox.";
        }

        public static Mailbox AddNewMailbox(Mailboxes mailboxes, string firstName, string lastName, Sizes size)
        {
            if(mailboxes is null)
            {
                throw new ArgumentNullException(nameof(mailboxes));
            }
            if (firstName is null)
            {
                throw new ArgumentNullException(nameof(firstName));
            }
            if (lastName is null)
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            Person owner = new Person(firstName, lastName);
            bool isOccupied;
            HashSet<Person> adjacentPeople = new HashSet<Person>();

            if (mailboxes.Count == 0)
            {
                Mailbox mailbox = new Mailbox(owner, (0, 0), size);
                return mailbox;
            }

            for(int x = 0; x < Width; x ++)
            {
                for(int y = 0; x < Height; y++)
                {
                    isOccupied = mailboxes.GetAdjacentPeople(x, y, out adjacentPeople);

                    if(!isOccupied)
                    {
                        if(!adjacentPeople.Contains(owner))
                        {
                            Mailbox mailbox = new Mailbox(owner, (x, y), size);
                            return mailbox;
                        }
                    }
                }
            }
            #pragma warning disable CS8603 // Possible null reference return.
            return null;
            #pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
