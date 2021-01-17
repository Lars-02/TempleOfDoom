using System;
using CODE_GameLib.Enums;

namespace CODE_PersistenceLib
{
    public static class Util
    {
        public static ConsoleColor ConvertJsonToConsoleColor(string color)
        {
            try
            {
                return (ConsoleColor) Enum.Parse(typeof(ConsoleColor), color, true);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new JsonException(
                    $"Invalid color in provided level file: {color}", e);
            }
        }

        public static Direction ConvertJsonToDirection(string direction)
        {
            try
            {
                return (Direction) Enum.Parse(typeof(Direction), direction, true);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new JsonException(
                    $"Invalid location in provided level file: {direction}", e);
            }
        }
    }
}