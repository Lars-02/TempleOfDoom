using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib
{
    public class ConveyorBelt : IConveyorBelt
    {
        public int X { get; }
        public int Y { get; }
        
        public Direction Direction { get; }

        public ConveyorBelt(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
    }
}