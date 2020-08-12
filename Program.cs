using System;
using System.Collections.Generic;
using Houselike_Random;

namespace Housing_Catalogue
{
    enum HousingType
    {
        Undefined = 0,
        Cottage,
        Flat,
        Room,
    }
   
    static class Program
    {

        static private List<IHousing> db = new List<IHousing>();

        static void Main()
        {
            Program.CreateDB();
            //db = Randomizer.GetHousing(); //Uncomment if you want a 1-20 random list of stuff
            Console.Clear();
           
            while (true)
            {
                Console.Clear();
                int nextAction;
                Program.FullDisplay();
                Console.WriteLine("Please, select your next action or enter -1 to leave the program");
                Console.WriteLine("Actions:\n" +
                    "0: Create a whole new list\n" +
                    "1: Sort by name\n" +
                    "2: Sort by price\n" +
                    "3: Sort by total living area\n" +
                    "4: Sort by distance to the city centre\n" +
                    "5: Sort by total sleeping spots\n" +
                    "6: Add new item\n" +
                    "7: Remove item from list");

                nextAction = Housing.InputNumber(-2, 8);
                if (-1 <= nextAction && nextAction <=7)
                switch (nextAction)
                {
                        case -1:
                            {
                                return;
                            }
                        case 0:
                            {
                                CreateDB();
                                break;
                            }
                        case 1:
                            {
                                db.Sort(CompareByName);
                                break;
                            }
                        case 2:
                            {
                                db.Sort(CompareByPrice);
                                break;
                            }
                        case 3:
                            {
                                List<IHasTotalArea> areas = new List<IHasTotalArea>();
                                foreach (var item in db)
                                {
                                    areas.Add((IHasTotalArea)item);
                                }

                                areas.Sort(CompareByTotalArea);

                                db.Clear();

                                foreach (var item in areas)
                                {
                                    db.Add((IHousing)item);
                                }

                                break;
                            }
                        case 4:
                            {
                                db.Sort(CompareByRemoteness);
                                break;
                            }
                        case 5:
                            {
                                List<IHasBeds> beds = new List<IHasBeds>();
                                foreach (var item in db)
                                {
                                    beds.Add((IHasBeds)item);
                                }

                                beds.Sort(CompareByTotalBeds);

                                db.Clear();

                                foreach (var item in beds)
                                {
                                    db.Add((IHousing)item);
                                }
                                break;
                            }
                        case 6:
                            {
                                InputHousingToList();
                                break;
                            }
                        case 7:
                            {
                                RemoveItem();
                                break;
                            }

                        default:
                        {
                            
                        }
                        break;
                }

            }

        }

        #region Comparers
        static public int CompareByTotalArea(IHasTotalArea x, IHasTotalArea y)
        {
            if (x.TotalArea == y.TotalArea)
            {
                return 0;
            }
            else if (x.TotalArea < y.TotalArea)
            {
                return -1;
            }
            else return 1;
        }

        static public int CompareByPrice(IHousing x, IHousing y)
        {
            if (x.Price == y.Price)
            {
                return 0;
            }
            else if (x.Price < y.Price)
            {
                return -1;
            }
            else return 1;
        }

        static public int CompareByRemoteness(IHousing x, IHousing y)
        {
            if (x.Remoteness == y.Remoteness)
            {
                return 0;
            }
            else if (x.Remoteness > y.Remoteness)
            {
                return -1;
            }
            else return 1;
        }

        static public int CompareByName(IHousing x, IHousing y)
        {
            return string.Compare(x.Name, y.Name);
        }

        static public int CompareByTotalBeds(IHasBeds x, IHasBeds y)
        {
            if (x.NumberOfBeds == y.NumberOfBeds)
            {
                return 0;
            }
            else if (x.NumberOfBeds < y.NumberOfBeds)
            {
                return -1;
            }
            else return 1;
        } 
        #endregion

        static void RemoveItem()
        {
            int parameter;

            Console.WriteLine("Select needed parameter\n" +
                "1: Name\n" +
                "2: Price\n" +
                "3: Remoteness\n");
            parameter = Housing.InputNumber(0, 4);
            switch (parameter)
            {
                case 1:
                    {
                        Console.WriteLine("Enter the name:");
                        string wanted = Console.ReadLine();

                        if (db.Exists(item => item.Name == wanted))
                        {
                            db.Remove(db.Find(item => item.Name == wanted));
                        }
                        else Console.WriteLine("No such item exists");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Enter the Price:");
                        double wanted = Housing.InputDouble();

                        if (db.Exists(item => item.Price == wanted))
                        {
                            db.Remove(db.Find(item => item.Price == wanted));
                        }
                        else Console.WriteLine("No such item exists");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Enter the Remoteness:");
                        double wanted = Housing.InputDouble();

                        if (db.Exists(item => item.Remoteness == wanted))
                        {
                            db.Remove(db.Find(item => item.Remoteness == wanted));
                        }
                        else Console.WriteLine("No such item exists");
                        break;
                    }
                default:
                    break;
            }
        }


        static void FullDisplay()
        {
            Console.WriteLine("Your list:");
            foreach (var item in db)
            {
                item.FullOutput();
            }
        }

        static void CreateDB()
        {
            db = new List<IHousing>();
            Console.WriteLine("How many items do you want to be in your list?");
            var items = Housing.InputNumber(0);
            for (int i = 0; i < items; i++)
            {
                InputHousingToList();
            }

        }

        static void InputHousingToList()
        {
            IRoom ExampleRoom = new Room(0, 0);
            IFlat ExampleFlat = new Flat(ExampleRoom, true);
            Console.Clear();
            Console.WriteLine("Enter 1 to add a Cottage, 2 to add a Flat or 3 to add a Room");
            var item = Housing.InputNumber(0,4);
            switch (item)
            {
                case 1:
                    {
                        db.Add(new Cottage(ExampleFlat));
                        break;
                    }
                case 2:
                    {
                        db.Add(new Flat(ExampleRoom));
                        break;
                    }
                case 3:
                    {
                        db.Add(new Room());
                        break;
                    }
                default:
                    {
                        break;
                    }

            }
        }

    }
}
