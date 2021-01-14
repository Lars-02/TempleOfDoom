using System.Collections.Generic;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Location;
using Newtonsoft.Json.Linq;

namespace CODE_PersistenceLib.Factories
{
    public static class EntityLocationFactory
    {
        public static IEntityLocation CreateEntityLocation(IReadOnlyDictionary<int, IRoom> rooms, JToken playerJToken)
        {
            return new EntityLocation(
                rooms[playerJToken["startRoomId"].Value<int>()],
                playerJToken["startX"].Value<int>(),
                playerJToken["startY"].Value<int>()
            );
        }
    }
}
