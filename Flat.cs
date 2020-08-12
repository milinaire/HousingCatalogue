using System;
using System.Collections.Generic;

namespace Housing_Catalogue
{
    class Flat :Housing, IFlat
    {
        IRoom Room;

        List<IRoom> Rooms = new List<IRoom>();
        private int numberofrooms = 0;
        private int numberofbeds = 0;

        public Flat(string Name, double Price, double Remoteness, IRoom Room, List<IRoom> Rooms):base(Name,Price,Remoteness)
        {
            this.Rooms = Rooms;
            numberofrooms = Rooms.Count;
            this.Room = Room;
            this.type_ = HousingType.Flat;
        }

        public Flat(IRoom Room, List<IRoom> Rooms)
        {
            this.Room = Room;
            this.Rooms = Rooms;
            numberofrooms = Rooms.Count;
        }

        public Flat(IRoom Room, bool empty = false)
        {
            this.Room = Room;
            this.type_ = HousingType.Flat;
            if (!empty)
            {
                base.Input();
                this.Input();
            }
        }

        public int NumberOfRooms
        {
            get => numberofrooms;
        }

        public int NumberOfBeds
        {
            get
            {
                int beds = 0;
                foreach (var item in Rooms)
                {
                    beds += item.NumberOfBeds;
                }
                return beds;
            }
        }

        public void AddRoom(IRoom Room)
        {
            Rooms.Add(Room.Clone());
            numberofrooms++;
            numberofbeds += Room.NumberOfBeds;
        }

        public double TotalArea
        {
            get
            {
                double TotalArea = 0;
                foreach (var item in Rooms)
                {
                    TotalArea += item.TotalArea;
                }
                return TotalArea;
            }
        }

        public override void Input()
        {
            Console.WriteLine("How many rooms?");
            var temp = InputNumber(0);
            for (int i = 0; i < temp; i++)
            {
                Console.Clear();
                Console.WriteLine("Room#{0}", i+1);
                Room.Input();
                this.AddRoom(Room.Clone());
            }
        }

        public override void FullOutput()
        {
            base.FullOutput();
            Console.WriteLine("It has {0} rooms", this.NumberOfRooms);
            var i = 0;
            foreach (var item in Rooms)
            {
                Console.WriteLine("Room#{0}", ++i);
                item.PartialOutput();
            }
        }

        public override void PartialOutput()
        {
            var i = 0;
            foreach (var item in Rooms)
            {
                Console.WriteLine("Room{0}", ++i);
                item.PartialOutput();
            }   
        }

        public IFlat Clone()
        {
            List<IRoom> NewRooms = new List<IRoom>();
            NewRooms.AddRange(Rooms);
            IFlat Flat = new Flat(Room, NewRooms);
            return Flat;
        }

        public void ClearRooms()
        {
            Rooms.Clear();
            Rooms = new List<IRoom>();
        }

    }
}
