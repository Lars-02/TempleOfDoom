using CODE_GameLib.Interfaces.RoomObjects;

namespace CODE_GameLib.Objects.RoomObjects
{
    public class RoomRoomObject : IRoomObject
    {
        public RoomRoomObject(int y, int x)
        {
            Y = y;
            X = x;
        }

        public int X { get; }
        public int Y { get; }
    }
}