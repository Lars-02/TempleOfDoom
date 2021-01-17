namespace CODE_GameLib.RoomObjects
{
    public abstract class RoomObject : IRoomObject
    {
        protected RoomObject(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }

    public interface IRoomObject
    {
        public int X { get; }
        public int Y { get; }
    }
}