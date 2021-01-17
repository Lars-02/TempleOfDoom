using CODE_GameLib.Enums;

namespace CODE_GameLib.Interfaces.RoomObjects
{
    public interface IConveyorBelt : IRoomObject
    {
        Direction Direction { get; }
    }
}