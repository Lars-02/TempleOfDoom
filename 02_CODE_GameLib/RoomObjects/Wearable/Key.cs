using System;

namespace CODE_GameLib.RoomObjects.Wearable
{
    public class Key : Wearable, IKey
    {
        public Key(ILocation location, ConsoleColor color) : base(new RoomObject(location.X, location.Y), location.Room)
        {
            Color = color;
        }

        public ConsoleColor Color { get; }
    }

    public interface IKey
    {
        public ConsoleColor Color { get; }
    }
}