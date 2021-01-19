using CODE_GameLib.Entity;

namespace CODE_GameLib.RoomObjects
{
    public class RoomObject : IRoomObject
    {
        public RoomObject(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public virtual void Interact(IEntity entity)
        {
        }
    }

    public interface IRoomObject
    {
        public int X { get; }
        public int Y { get; }
        public void Interact(IEntity entity);
    }
}