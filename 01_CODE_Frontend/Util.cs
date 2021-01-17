using System;
using CODE_GameLib.Enums;

namespace CODE_Frontend
{
    public static class Util
    {
        public static string ConvertDirectionConveyorBeltIcon(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return "▲";
                case Direction.East:
                    return "▶";
                case Direction.South:
                    return "▼";
                case Direction.West:
                    return "◀";
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, "This is an invalid direction");
            }
        }
    }
}
