using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Items;
using CODE_GameLib.Location;
using Newtonsoft.Json.Linq;

namespace CODE_PersistenceLib.Factories
{
    public static class PortalFactory
    {
        
        public static void CreatePortal(JObject jConnection,  IReadOnlyDictionary<int, IRoom> rooms, out IPortal portal1, out int roomId1, out IPortal portal2, out int roomId2)
        {
            var portalList = jConnection["portal"].Children<JObject>().ToList();
            
            roomId1 = portalList[0]["roomId"].Value<int>();
            roomId2 = portalList[1]["roomId"].Value<int>();

            var destination1 = new Location(portalList[1]["x"].Value<int>(), portalList[1]["y"].Value<int>(), rooms[portalList[1]["roomId"].Value<int>()]);
            var destination2 = new Location(portalList[0]["x"].Value<int>(), portalList[0]["y"].Value<int>(), rooms[portalList[0]["roomId"].Value<int>()]);
            
            portal1 = new Portal(portalList[0]["x"].Value<int>(), portalList[0]["y"].Value<int>(), destination1);
            portal2 = new Portal(portalList[1]["x"].Value<int>(), portalList[1]["y"].Value<int>(), destination2);
        }
    }
}