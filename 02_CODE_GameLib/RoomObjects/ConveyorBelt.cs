using CODE_GameLib.Entity;
using CODE_GameLib.Enums;

namespace CODE_GameLib.RoomObjects
{
    public class ConveyorBelt : RoomObject, IConveyorBelt
    {
        public ConveyorBelt(int x, int y, Direction direction) : base(x, y)
        {
            Direction = direction;
        }

        public Direction Direction { get; }
        
        public bool UseConveyorBelt(IEntity entity)
        {
            return entity.Push(Direction);
        }
    }

    public interface IConveyorBelt : IRoomObject
    {
        Direction Direction { get; }
        public bool UseConveyorBelt(IEntity entity);
    }
    
    
}