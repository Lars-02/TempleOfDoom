using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces.RoomObjects;

namespace CODE_GameLib.Objects.RoomObjects
{
    public class ConveyorBelt : RoomObject, IConveyorBelt
    {
        public ConveyorBelt(int x, int y, Direction direction) : base(x, y) => Direction = direction;
        
        public Direction Direction { get; }
    }
}