using CODE_GameLib.Enums;

namespace CODE_GameLib.Interfaces.Items
{
    public interface IConveyorBelt : IItem
    {
        Direction Direction { get; }
    }
}