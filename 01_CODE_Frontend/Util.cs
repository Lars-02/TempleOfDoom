using System;
using CODE_GameLib.Enums;

namespace CODE_Frontend
{
    public static class Util
    {
        public static string ConvertDirectionConveyorBeltIcon(Direction direction)
        {
            return direction switch
            {
                Direction.North => "▲",
                Direction.East => "▶",
                Direction.South => "▼",
                Direction.West => "◀",
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, "This is an invalid direction")
            };
        }
    }
}