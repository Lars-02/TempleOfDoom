using System.Collections.Generic;
using System.Linq;
using CODE_GameLib;
using CODE_GameLib.RoomObjects;
using Newtonsoft.Json.Linq;

namespace CODE_PersistenceLib.Factories
{
    public static class PortalFactory
    {
        public static void CreatePortal(JObject jConnection, IReadOnlyDictionary<int, IRoom> rooms)
        {
            var portalList = jConnection["portal"]?.Children<JObject>().ToList();

            var room1 = rooms[portalList[0]["roomId"].Value<int>()];
            var room2 = rooms[portalList[1]["roomId"].Value<int>()];

            var location1 = new Location(room1,
                portalList[0]["x"].Value<int>(), portalList[0]["y"].Value<int>());
            var location2 = new Location(room2,
                portalList[1]["x"].Value<int>(), portalList[1]["y"].Value<int>());

            room1.AddRoomObject(new Portal(location1.X, location1.Y, location2));
            room2.AddRoomObject(new Portal(location2.X, location2.Y, location1));
        }
    }
}