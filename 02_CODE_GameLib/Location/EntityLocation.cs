using CODE_GameLib.Interfaces;
using CODE_GameLib.Observers;

namespace CODE_GameLib.Location
{
    public class EntityLocation : BaseObservable<IEntityLocation>, IEntityLocation
    {
        public IRoom Room { get; private set; }

        public int X { get; private set; }

        public int Y { get; private set; }

        public EntityLocation(IRoom room, int x, int y)
        {
            Room = room;
            X = x;
            Y = y;
        }

        public bool Update(IRoom room, int x, int y)
        {
            if (room == null || x < 0 || y < 0 || x > room.Width - 1 || y > room.Height - 1)
                return false;
            Room = room;
            X = x;
            Y = y;
            NotifyObservers(this);
            return true;
        }
    }
}
