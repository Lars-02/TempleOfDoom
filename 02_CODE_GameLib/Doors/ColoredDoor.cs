using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items.Wearable;
using System.Drawing;
using System.Linq;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Doors
{
    public class ColoredDoor : IColoredDoor
    {
        public bool Opened { get; set; }
        public Color Color { get; }

        public ColoredDoor(Color color)
        {
            Color = color;
        }

        public bool PassThru(IPlayer player)
        {
            if (player.Inventory.Where(item => item is IKey).Any(key => ((IKey)key).Color == Color))
                Opened = true;
            return Opened;
        }
    }
}
