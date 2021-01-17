using System;
using CODE_GameLib.Interfaces.RoomObjects.Wearable;

namespace CODE_GameLib.Objects.RoomObjects
{
    public class Key : RoomObject, IKey
    {
        public Key(int x, int y, ConsoleColor color) : base(x, y) => Color = color;
        
        public ConsoleColor Color { get; }
    }
}