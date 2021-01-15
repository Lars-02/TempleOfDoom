using System;
using System.Drawing;
using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Items;
using Newtonsoft.Json.Linq;

namespace CODE_PersistenceLib.Factories
{
    public static class ItemFactory
    {
        public static IItem CreateItem(JToken itemJToken)
        {
            var x = itemJToken["x"].Value<int>();
            var y = itemJToken["y"].Value<int>();

            return itemJToken["type"].Value<string>() switch
            {
                "boobietrap" => new BoobyTrap(x, y, itemJToken["damage"].Value<int>()),
                "disappearing boobietrap" => new DisappearingTrap(x, y, itemJToken["damage"].Value<int>()),
                "sankara stone" => new SankaraStone(x, y),
                "key" => new Key(x, y, Color.FromName(itemJToken["color"].Value<string>())),
                "pressure plate" => new PressurePlate(x, y),
                //     var convertLocation = new Dictionary<string, Direction>
                // {
                //     {"NORTH", Direction.North},
                //     {"EAST", Direction.East},
                //     {"SOUTH", Direction.South},
                //     {"WEST", Direction.West}
                // };
                // "conveyor belt" => new ConveyorBelt(x, y, Direction.TryParse(itemJToken["direction"])),
                // "portal" =>
                _ => throw new ArgumentException("Invalid item type")
            };
        }
    }
}