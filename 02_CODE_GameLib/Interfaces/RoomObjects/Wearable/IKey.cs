using System;

namespace CODE_GameLib.Interfaces.RoomObjects.Wearable
{
    public interface IKey : IWearable
    {
        public ConsoleColor Color { get; }
    }
}