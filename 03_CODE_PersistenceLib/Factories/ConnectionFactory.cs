using System.Collections.Generic;
using System.Linq;
using CODE_GameLib;
using CODE_GameLib.Doors;
using CODE_GameLib.Enums;
using Newtonsoft.Json.Linq;

namespace CODE_PersistenceLib.Factories
{
    public static class ConnectionFactory
    {
        public static void CreateConnection(JObject jConnection, IReadOnlyDictionary<int, IRoom> rooms,
            out IConnection conn1, out IConnection conn2, out int roomId1, out int roomId2)
        {
            var convertLocation = new Dictionary<string, Direction>
            {
                {"NORTH", Direction.North},
                {"EAST", Direction.East},
                {"SOUTH", Direction.South},
                {"WEST", Direction.West}
            };

            var actualConnections = jConnection.Properties()
                .Where(jp => convertLocation.ContainsKey(jp.Name)).ToArray();

            roomId1 = actualConnections[0].Value.Value<int>();
            var location1 = convertLocation[actualConnections[0].Name];

            roomId2 = actualConnections[1].Value.Value<int>();
            var location2 = convertLocation[actualConnections[1].Name];

            IDoor connectionDoor = null;

            if (jConnection.ContainsKey("door"))
                connectionDoor = DoorFactory.CreateDoor(jConnection["door"]);

            conn1 = new Connection(rooms[roomId1], location1, connectionDoor);
            conn2 = new Connection(rooms[roomId2], location2, connectionDoor);

            conn1.Destination = conn2;
            conn2.Destination = conn1;
        }
    }
}