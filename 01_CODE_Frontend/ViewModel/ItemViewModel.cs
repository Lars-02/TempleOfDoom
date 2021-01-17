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
                IDisappearingTrap _ => new ConsoleText("@"),
                IBoobyTrap _ => new ConsoleText("Ο"),
                IKey key => new ConsoleText("K", key.Color),
                IPressurePlate _ => new ConsoleText("T"),
                IPortal _ => new ConsoleText("Π", ConsoleColor.Magenta),
                IConveyorBelt conveyorBelt => new ConsoleText(Util.ConvertDirectionConveyorBeltIcon(conveyorBelt.Direction)),

                _ => new ConsoleText("?")
            };
        }
    }
}
