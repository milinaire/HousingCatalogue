
namespace Housing_Catalogue
{
    interface IHousing
    {
        HousingType Type { get; }
        string Name { get; set; }
        double Price { get; set; }
        double Remoteness { get; set; }

        void Input();
        void FullOutput();
        void PartialOutput();
    }

    interface IRoom:IHousing, IHasTotalArea, IHasBeds
    {
        IRoom Clone();

    }

    interface IMultipleRooms
    {
        int NumberOfRooms { get; }
    }

    interface IHasBeds
    {
        int NumberOfBeds { get; }
    }

    interface IHasTotalArea
    {
        double TotalArea { get; }
    }

    interface IFlat:IMultipleRooms, IHasTotalArea, IHousing, IHasBeds
    {       
        void AddRoom(IRoom Room);
        IFlat Clone();
        void ClearRooms();
    }

    interface ICottage:IMultipleRooms, IHasTotalArea, IHousing, IHasBeds
    {
        void AddFloor(IFlat Flat);
        int NumberOfFloors { get; }
    }

}
