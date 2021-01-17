using System.Linq;
using CODE_GameLib.Observers;
using CODE_GameLib.RoomObjects;

namespace CODE_GameLib
{
    public class Location : BaseObservable<ILocation>, ILocation
    {
        public Location(IRoom room, int x, int y)
        {
            Room = room;
            X = x;
            Y = y;
        }

        protected Location()
        {
        }

        public virtual IRoom Room { get; protected set; }

        public virtual int X { get; protected set; }

        public virtual int Y { get; protected set; }

        public virtual bool SetLocation(ILocation location)
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

        public virtual IRoomObject GetItem()
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