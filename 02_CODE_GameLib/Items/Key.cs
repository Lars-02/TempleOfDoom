using System;
using CODE_GameLib.Interfaces.Items.Wearable;
using System.Drawing;

namespace CODE_GameLib.Items
{
    public class Key : IKey
    {
        public int X { get; }
        public int Y { get; }
        public ConsoleColor Color { get; }

        public Key(int x, int y, ConsoleColor color)
        {
            X = x;
            Y = y;
            Color = color;
        }
    }
}