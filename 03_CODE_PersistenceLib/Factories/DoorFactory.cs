using System;
using CODE_GameLib.Objects.Doors;
using Newtonsoft.Json.Linq;

namespace CODE_PersistenceLib.Factories
{
    public static class DoorFactory
    {
        public static IDoor CreateDoor(JToken doorJToken)
        {
            return doorJToken["type"].Value<string>() switch
            {
                "colored" => new ColoredDoor(Util.ConvertJsonToConsoleColor(doorJToken["color"].Value<string>())),
                "toggle" => new ToggleDoor(),
                "closing gate" => new ClosingDoor(),
                _ => throw new ArgumentException("Invalid door type")
            };
        }
    }
}