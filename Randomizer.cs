using System;
using System.Collections.Generic;

using Housing_Catalogue;
namespace Houselike_Random
{
    class Randomizer
    {
        static private Random rand = new Random();
        public static IRoom GetRoom()
        {
            IRoom room = new Room(rand.Next().ToString(), rand.Next(), rand.Next(), rand.Next() % 1000, rand.Next()%4);
            return room;
        }

        public static List<IRoom> GetRooms()
        {
            List<IRoom> temp = new List<IRoom>();
            for (int i = 0; i < rand.Next() % 5 + 1; i++)
                temp.Add(Randomizer.GetRoom());
            return temp;
        }

        public static IFlat GetFlat()
        {
            IFlat flat = new Flat(rand.Next().ToString(), rand.Next(), rand.Next(), GetRoom(), GetRooms());
            return flat;
        }

        public static List<IFlat> GetFlats()
        {
            List<IFlat> temp = new List<IFlat>();
            for (int i = 0; i < rand.Next() % 5 + 1; i++)
                temp.Add(Randomizer.GetFlat());
            return temp;
        }

        public static ICottage GetCottage()
        {
            ICottage cottage = new Cottage(rand.Next().ToString(), rand.Next(), rand.Next(), GetFlat(), GetFlats());
            return cottage;
        }

        public static List<IHousing> GetHousing()
        {
            List<IHousing> temp = new List<IHousing>();
            for (int i = 0; i < rand.Next() % 20 + 1; i++)
                switch (rand.Next() % 3)
                {
                    case 0:
                        {
                            temp.Add((Room)GetRoom());
                            break;
                        }
                    case 1:
                        {
                            temp.Add((Flat)GetFlat());
                            break;
                        }
                    case 2:
                        {
                            temp.Add((Cottage)GetCottage());
                            break;
                        }
                    default:
                        break;
                }
            return temp;
        }

    }
}
