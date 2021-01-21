using System;
using CODE_GameLib.RoomObjects;
using CODE_GameLib.RoomObjects.BoobyTraps;
using CODE_GameLib.RoomObjects.Wearable;

namespace CODE_Frontend.ViewModel
{
    public class ItemViewModel
    {
        private readonly IRoomObject _roomObject;

        public ItemViewModel(IRoomObject roomObject)
        {
            _roomObject = roomObject;
        }

        public int X => _roomObject.X;
        public int Y => _roomObject.Y;
        public ConsoleText View => GetItemConsoleText(_roomObject);

        private static ConsoleText GetItemConsoleText(IRoomObject roomObject)
        {
            return roomObject switch
            {
                ISankaraStone _ => new ConsoleText("S", ConsoleColor.DarkYellow),
                IDisappearingTrap _ => new ConsoleText("@"),
                IBoobyTrap _ => new ConsoleText("Ο"),
                IKey key => new ConsoleText("K", key.Color),
                IPressurePlate _ => new ConsoleText("T"),
                IPortal _ => new ConsoleText("Π", ConsoleColor.Magenta),
                IConveyorBelt conveyorBelt => new ConsoleText(
                    Util.ConvertDirectionConveyorBeltIcon(conveyorBelt.Direction)),

                _ => new ConsoleText("?")
            };
        }
    }
}