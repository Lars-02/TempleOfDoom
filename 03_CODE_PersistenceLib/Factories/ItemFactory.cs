using System;
using CODE_GameLib.Interfaces.RoomObjects;
using CODE_GameLib.Objects.RoomObjects;
using Newtonsoft.Json.Linq;

namespace CODE_PersistenceLib.Factories
{
    public static class ItemFactory
    {
        public static IRoomObject CreateItem(JToken itemJToken)
        {
            var x = itemJToken["x"].Value<int>();
            var y = itemJToken["y"].Value<int>();

            return itemJToken["type"].Value<string>() switch
            {
                "boobietrap" => new BoobyTrap(x, y, itemJToken["damage"].Value<int>()),
                "disappearing boobietrap" => new DisappearingTrap(x, y, itemJToken["damage"].Value<int>()),
                "sankara stone" => new SankaraStone(x, y),
                "key" => new Key(x, y, Util.ConvertJsonToConsoleColor(itemJToken["color"].Value<string>())),
                "pressure plate" => new PressurePlate(x, y),
                "conveyor belt" => new ConveyorBelt(x, y,
                    Util.ConvertJsonToDirection(itemJToken["direction"].Value<string>())),
                _ => throw new ArgumentException("Invalid item type")
            };
        }
    }
}