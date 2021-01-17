using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CODE_GameLib.Entity;
using CODE_GameLib.Observers;
using CODE_GameLib.RoomObjects;

namespace CODE_GameLib
{
    public class Location : BaseObservable<ILocation>, ILocation
    {
        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
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

        public virtual IRoomObject GetRoomObject()
        {
            return Room.Items.FirstOrDefault(item => item.X == X && item.Y == Y);
        }

        /// <summary>
        ///     Returns if this enemy can be hit from the given location.
        /// </summary>
        /// <param name="location"> The location where the shot will come from </param>
        /// <returns></returns>
        public bool WithinShootingRange(ILocation location)
        {
            return X == location.X + 1 && Y == location.Y ||
                   X == location.X - 1 && Y == location.Y ||
                   X == location.X && Y == location.Y + 1 ||
                   X == location.X && Y == location.Y - 1;
        }

        public bool IsEnemy(IEnumerable<IEnemy> enemies)
        {
            return enemies.Any(enemy => enemy.Location.X == X && enemy.Location.Y == Y && enemy.Location.Room == Room);
        }
    }

    public interface ILocation : IBaseObservable<ILocation>
    {
        public IRoom Room { get; }
        public int X { get; }
        public int Y { get; }

        public bool SetLocation(ILocation location);
        public IRoomObject GetRoomObject();
        public bool WithinShootingRange(ILocation location);
        public bool IsEnemy(IEnumerable<IEnemy> enemies);
    }
}