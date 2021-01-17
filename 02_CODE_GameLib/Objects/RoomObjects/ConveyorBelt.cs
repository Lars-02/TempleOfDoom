using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces.RoomObjects;

namespace CODE_GameLib.Objects.RoomObjects
{
    public class ConveyorBelt : IConveyorBelt
    {
        public ConveyorBelt(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public int X { get; }
        public int Y { get; }

        public Direction Direction { get; }
    }
}