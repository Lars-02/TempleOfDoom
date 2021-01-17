using System;
using System.Linq;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.RoomObjects.Wearable;

namespace CODE_GameLib.Objects.Doors
{
    public class ColoredDoor : Door, IColoredDoor
    {
        public ColoredDoor(ConsoleColor color)
        {
            Color = color;
        }

        public ConsoleColor Color { get; }

        public override bool PassThru(IEntity entity)
        {
            if (!(entity is IPlayer player))
                return false;
            if (player.Inventory.Where(item => item is IKey).Any(key => ((IKey) key).Color == Color))
                Opened = true;
            return Opened;
        }
    }
}