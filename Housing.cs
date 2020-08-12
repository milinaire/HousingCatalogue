using System;

namespace Housing_Catalogue
{
    class Housing : IHousing
    {
        protected HousingType type_;

        public HousingType Type
        {
            get => type_;
        }

        public string Name
        {
            get; set;
        }
        public double Price { get; set; }
        public double Remoteness { get; set; }


        public Housing(string Name, double Price, double Remoteness)
        {
            this.Name = Name;
            this.Price = Price;
            this.Remoteness = Remoteness;
            this.type_ = HousingType.Undefined;
        }

        public Housing()
        {
            this.Name = "Blank";
            this.Price = -1;
            this.Remoteness = -1;
        }

        virtual public void Input()
        {
            Console.WriteLine("Name this {0}", this.type_.ToString());
            this.Name = Console.ReadLine();
            Console.WriteLine("What's the price?");
            this.Price = InputNumber(0);
            Console.WriteLine("And what's the distance to the city centre?");
            this.Remoteness = InputNumber(0);
        }

        virtual public void FullOutput()
        {
            Console.WriteLine("\nThis {0} is named {1}. It costs {2} per night and is {3}m away from the city centre.", this.type_.ToString(), this.Name, this.Price, this.Remoteness);
        }

        virtual public void PartialOutput()
        {
            this.FullOutput();
        }

        public static int InputNumber(int min = 0, int max = int.MaxValue)
        {
            int number = min - 1;
            string input = "";
            input = Console.ReadLine();
            while (!(int.TryParse(input, out number)) || number <= min || number >= max)
            {
                Console.WriteLine("Please, enter a valid value");
                input = Console.ReadLine();
            }
            return number;
        }

        public static double InputDouble(double min = 0, double max = double.MaxValue)
        {
            double number = min - 1;
            string input = "";
            input = Console.ReadLine();
            while (!(double.TryParse(input, out number)) || number <= min || number >= max)
            {
                Console.WriteLine("Please, enter a valid value");
                input = Console.ReadLine();
            }
            return number;
        }

    }
}
