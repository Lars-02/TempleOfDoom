using System.Linq;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Observers;

namespace CODE_GameLib
{
    public class Location : BaseObservable<ILocation>, ILocation
    {
        public IRoom Room { get; private set; }

        public int X { get; private set; }

        public int Y { get; private set; }
        
        public Location(IRoom room, int x, int y)
        {
            Room = room;
            X = x;
            Y = y;
        }

        public bool SetLocation(ILocation location)
        {
            if (location.Room == null || location.X < 0 || location.Y < 0 || location.X > location.Room.Width - 1 || location.Y > location.Room.Height - 1)
                return false;
            Room = location.Room;
            X = location.X;
            Y = location.Y;
            NotifyObservers(this);
            return true;
        }
        
        public IItem GetItem() => Room.Items.FirstOrDefault(item => item.X == X && item.Y == Y);
    }
}
