using System;
using CODE_GameLib.Interfaces.RoomObjects.Wearable;

namespace CODE_GameLib.Objects.RoomObjects
{
    public class Key : IKey
    {
        public Key(int x, int y, ConsoleColor color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        public int X { get; }
        public int Y { get; }
        public ConsoleColor Color { get; }
    }
}