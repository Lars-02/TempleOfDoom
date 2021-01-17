using System;
using System.Linq;
using CODE_GameLib.Objects.Entity;
using CODE_GameLib.Objects.RoomObjects.Wearable;

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

    public interface IColoredDoor : IDoor
    {
        public ConsoleColor Color { get; }
    }
}