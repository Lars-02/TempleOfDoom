using System;

namespace CODE_GameLib.Interfaces.Items.Wearable
{
    public interface IKey : IWearable
    {
        public ConsoleColor Color { get; }
    }
}
