using CODE_GameLib.Interfaces;

namespace CODE_GameLib.Location
{
    public class Location : ILocation
    {
        public int X { get; }
        public int Y { get; }
        public IRoom Room { get; }

        public Location(int x, int y, IRoom room)
        {
            X = x;
            Y = y;
            Room = room;
        }
    }
}