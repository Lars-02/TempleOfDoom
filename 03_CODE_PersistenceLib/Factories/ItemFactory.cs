using System;
using CODE_GameLib;
using CODE_GameLib.RoomObjects;
using CODE_GameLib.RoomObjects.BoobyTraps;
using CODE_GameLib.RoomObjects.Wearable;
using Newtonsoft.Json.Linq;

// ReSharper disable AssignNullToNotNullAttribute
namespace CODE_PersistenceLib.Factories
{
    public static class ItemFactory
    {
        // ReSharper disable once UnusedMethodReturnValue.Global
        public static IRoomObject CreateItem(JToken itemJToken, IRoom room)
        {
            var x = itemJToken["x"].Value<int>();
            var y = itemJToken["y"].Value<int>();

            var location = new Location(room, x, y);

            return itemJToken["type"].Value<string>() switch
            {
                "boobietrap" => new BoobyTrap(x, y, itemJToken["damage"].Value<int>()),
                "disappearing boobietrap" => new DisappearingTrap(location, itemJToken["damage"].Value<int>()),
                "sankara stone" => new SankaraStone(location),
                "key" => new Key(location, Util.ConvertJsonToConsoleColor(itemJToken["color"].Value<string>())),
                "pressure plate" => new PressurePlate(x, y, room.Connections),
                "conveyor belt" => new ConveyorBelt(x, y,
                    Util.ConvertJsonToDirection(itemJToken["direction"].Value<string>())),
                _ => throw new ArgumentException("Invalid item type")
            };
        }
    }
}