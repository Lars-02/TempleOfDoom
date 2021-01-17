using System;

namespace CODE_GameLib.Objects.RoomObjects.Wearable
{
    public class Key : RoomObject, IKey
    {
        public Key(int x, int y, ConsoleColor color) : base(x, y)
        {
            Color = color;
        }

        public ConsoleColor Color { get; }
    }

    public interface IKey : IWearable
    {
        public ConsoleColor Color { get; }
    }
}