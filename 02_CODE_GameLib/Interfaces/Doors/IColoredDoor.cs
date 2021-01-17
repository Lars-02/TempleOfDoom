using System;
using System.Drawing;

namespace CODE_GameLib.Interfaces.Doors
{
    public interface IColoredDoor : IDoor
    {
        public ConsoleColor Color { get; }
    }
}
