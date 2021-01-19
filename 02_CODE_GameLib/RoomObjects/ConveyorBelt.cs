using CODE_GameLib.Enums;
using CODE_GameLib.RoomObjects.Decorators;

namespace CODE_GameLib.RoomObjects
{
    public class ConveyorBelt : BaseRoomObjectDecorator, IConveyorBelt
    {
        public ConveyorBelt(int x, int y, Direction direction) : base(
            new PushEntityObjectDecorator(new RoomObject(x, y), direction))
        {
            Direction = direction;
        }

        public Direction Direction { get; }
    }

    public interface IConveyorBelt
    {
        Direction Direction { get; }
    }
}