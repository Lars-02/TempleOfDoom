using System;
using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Interfaces.Items.BoobyTraps;
using CODE_GameLib.Interfaces.Items.Wearable;

namespace CODE_Frontend.ViewModel
{
    public class ItemViewModel
    {
        private readonly IItem _item;

        public int X => _item.X;
        public int Y => _item.Y;
        public ConsoleText View => GetItemConsoleText(_item);

        public ItemViewModel(IItem item)
        {
            _item = item;
        }

        private static ConsoleText GetItemConsoleText(IItem item)
        {
            return item switch
            {
                ISankaraStone _ => new ConsoleText("S", ConsoleColor.DarkYellow),
                IDisappearingTrap _ => new ConsoleText("@", ConsoleColor.White),
                IBoobyTrap _ => new ConsoleText("Ο", ConsoleColor.White),
                IKey key => new ConsoleText("K", Util.ColorToConsoleColor(key.Color)),
                IPressurePlate _ => new ConsoleText("T", ConsoleColor.White),
                IPortal _ => new ConsoleText("Π", ConsoleColor.Magenta),
                _ => new ConsoleText("?")
            };
        }
    }
}
