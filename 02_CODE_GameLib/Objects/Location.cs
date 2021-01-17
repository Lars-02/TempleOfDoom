using System.Linq;
using CODE_GameLib.Objects.Observers;
using CODE_GameLib.Objects.RoomObjects;

namespace CODE_GameLib.Objects
{
    public class Location : BaseObservable<ILocation>, ILocation
    {
        public Location(IRoom room, int x, int y)
        {
            Room = room;
            X = x;
            Y = y;
        }

        public IRoom Room { get; private set; }

        public int X { get; private set; }

        public int Y { get; private set; }

        public bool SetLocation(ILocation location)
        {
            if (location.Room == null || location.X < 0 || location.Y < 0 || location.X > location.Room.Width - 1 ||
                location.Y > location.Room.Height - 1)
                return false;
            Room = location.Room;
            X = location.X;
            Y = location.Y;
            NotifyObservers(this);
            return true;
        }

        public IRoomObject GetItem()
        {
            return Room.Items.FirstOrDefault(item => item.X == X && item.Y == Y);
        }
    }

    public interface ILocation : IBaseObservable<ILocation>
    {
        public IRoom Room { get; }
        public int X { get; }
        public int Y { get; }

        public bool SetLocation(ILocation location);
        public IRoomObject GetItem();
    }
}