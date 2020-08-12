using System;


namespace Housing_Catalogue
{
    class Room :Housing, IRoom
    {
        private double livingarea_ = 0;
        private int beds_ = 0;

        public double TotalArea
        {
            get => this.livingarea_;
            set
            {
                if (value >= 0)
                    this.livingarea_ = value;
            }
        }

        public int NumberOfBeds
        {
            get => this.beds_;
            set
            {
                if (value >= 0)
                    this.beds_ = value;
            }
        }

        public Room(double LivingArea = 0, int Beds = 0)
        {
            this.TotalArea = LivingArea;
            this.NumberOfBeds = Beds;
            this.type_ = HousingType.Room;
        }

        public Room(string Name, double Price, double Remoteness, double LivingArea, int Beds):base(Name,Price,Remoteness)
        {
            this.TotalArea = LivingArea;
            this.NumberOfBeds = Beds;
            this.type_ = HousingType.Room;
        }

        public Room()
        {
            this.type_ = HousingType.Room;
            base.Input();
            this.Input();
        }

        public Room(ref IRoom Room)
        {
            this.NumberOfBeds = Room.NumberOfBeds;
            this.TotalArea = Room.TotalArea;
        }

        override public void Input()
        {
            Console.WriteLine("Input the total area (m^2)");
            this.TotalArea = InputDouble(0);
            Console.WriteLine("How many beds?");
            this.NumberOfBeds = InputNumber(-1);
        }

        public override void FullOutput()
        {
            base.FullOutput();
            Console.WriteLine("It's total area is {0}m^2 and it has {1} beds.", this.TotalArea, this.NumberOfBeds);
        }

        public override void PartialOutput()
        {
            Console.WriteLine("The total area of this room is {0}m^2 and it has {1} beds", this.TotalArea, this.NumberOfBeds);
        }

        public IRoom Clone()
        {
            IRoom Room = new Room(this.TotalArea, this.NumberOfBeds);
            return Room;
        }
    }
}
