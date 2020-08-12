using System;
using System.Collections.Generic;

namespace Housing_Catalogue
{
    class Cottage : Housing, ICottage
    {
        private int numberofrooms = 0;
        private int numberoffloors = 0;
        private int numberofbeds = 0;

        private IFlat Floor;

        List<IFlat> Floors = new List<IFlat>();

        public Cottage(IFlat Floor, List<IFlat> Floors):this(Floor)
        {
            this.Floors = Floors;
            foreach (var item in Floors)
            {
                this.numberofbeds += item.NumberOfBeds;
                this.numberoffloors++;
                this.numberofrooms += item.NumberOfRooms;
            }
        }
        public Cottage(IFlat Floor, bool empty = false)
        {
            this.Floor = Floor;
            this.type_ = HousingType.Cottage;
            if (!empty)
            {
                base.Input();
                this.Input();
            }
        }

        public Cottage(string Name, double Price, double Remoteness, IFlat Floor, List<IFlat> Floors):base(Name, Price, Remoteness)
        {
            this.Floor = Floor;
            this.type_ = HousingType.Cottage;
            this.Floors = Floors;
            foreach (var item in Floors)
            {
                this.numberofbeds += item.NumberOfBeds;
                this.numberoffloors++;
                this.numberofrooms += item.NumberOfRooms;
            }
        }

        public int NumberOfFloors
        {
            get => numberoffloors;
        }

        public int NumberOfRooms
        {
            get => numberofrooms;
        }

        public int NumberOfBeds
        {
            get => numberofbeds;
        }

        public double TotalArea
        {
            get
            {
                double TotalArea = 0;
                foreach (var item in Floors)
                {
                    TotalArea += item.TotalArea;
                }
                return TotalArea;
            }
        }

        public void AddFloor(IFlat Flat)
        {
            this.numberoffloors++;
            Floors.Add(Flat.Clone());
            this.numberofrooms += Flat.NumberOfRooms;
            this.numberofbeds += Flat.NumberOfBeds;
        }

        public override void Input()
        {
            Console.WriteLine("How many floors?");
            var temp = InputNumber(0);
            for (int i = 0; i < temp; i++)
            {
                Console.Clear();
                Console.WriteLine("Floor#{0}", i+1);
                Floor.Input();
                this.AddFloor(Floor.Clone());
                Floor.ClearRooms();
            }
        }

        public override void FullOutput()
        {
            base.FullOutput();
            int i = 0;
            Console.WriteLine("It has {0} floors", this.NumberOfFloors);
            foreach (var item in Floors)
            {
                Console.WriteLine("Floor#{0} has {1} rooms", ++i, item.NumberOfRooms);
                item.PartialOutput();
            }

        }

    }
}
