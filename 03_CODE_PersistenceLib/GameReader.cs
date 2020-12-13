using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using CODE_GameLib;
using CODE_GameLib.Doors;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Interfaces.Items.Doors;
using CODE_GameLib.Items;
using CODE_GameLib.Items.Doors;
using Newtonsoft.Json.Linq;

namespace CODE_PersistenceLib
{
    public static class GameReader
    {
        public static Game Read(string filePath)
        {
            var rooms = new Dictionary<int, IRoom>();
            IPlayer player;

            try
            {
                var json = JObject.Parse(File.ReadAllText(filePath));

                var connections = new Dictionary<int, List<IConnection>>();

                SetRooms(json, connections, rooms);
                SetConnections(json, connections, rooms);
                
                var playerJToken = json["player"];
                var playerStartLocation = GetPlayerStartLocation(rooms, playerJToken);
                player = GetPlayer(playerJToken, playerStartLocation);
            }
            catch (Exception e)
            {
                throw new JsonException("The provided JSON level file is not valid.", e);
            }

            return new Game(player, rooms.Values);
        }

        private static IPlayer GetPlayer(JToken playerJToken, IPlayerLocation playerLocation)
        {
            return new Player(
                playerJToken["lives"].Value<int>(),
                new List<IKey>(),
                new List<ISankaraStone>(),
                playerLocation
            );
        }

        private static IPlayerLocation GetPlayerStartLocation(IReadOnlyDictionary<int, IRoom> rooms, JToken playerJToken)
        {
            return new PlayerLocation(
                rooms[playerJToken["startRoomId"].Value<int>()],
                playerJToken["startX"].Value<int>(),
                playerJToken["startY"].Value<int>()
            );
        }

        private static void SetRooms(JObject json, IDictionary<int, List<IConnection>> connections, IDictionary<int, IRoom> rooms)
        {
            foreach (JObject roomJObject in json["rooms"])
            {
                var roomId = roomJObject["id"].Value<int>();
                connections.Add(roomId, new List<IConnection>());

                var items = GetItemsForRoom(roomJObject);

                rooms.Add(roomId, new Room(
                    roomJObject["width"].Value<int>(),
                    roomJObject["height"].Value<int>(),
                    items,
                    connections[roomId]
                ));
            }
        }

        private static IEnumerable<IItem> GetItemsForRoom(JObject roomJObject)
        {
            var items = new List<IItem>();
            
            if (!roomJObject.ContainsKey("items")) return items;
            
            foreach (var itemJToken in roomJObject["items"])
            {
                var x = itemJToken["x"].Value<int>();
                var y = itemJToken["y"].Value<int>();

                switch (itemJToken["type"].Value<string>())
                {
                    case "boobietrap":
                    case "disappearing boobietrap":
                    {
                        items.Add(new BoobyTrap(x, y,
                            itemJToken["damage"].Value<int>(),
                            itemJToken["type"].Value<string>().Contains("disappearing")
                        ));
                        break;
                    }
                    case "sankara stone":
                    {
                        items.Add(new SankaraStone(x, y));
                        break;
                    }
                    case "key":
                    {
                        items.Add(new Key(x, y,
                            Color.FromName(itemJToken["color"].Value<string>())
                        ));
                        break;
                    }
                    case "pressure plate":
                    {
                        items.Add(new PressurePlate(x, y));
                        break;
                    }
                }
            }

            return items;
        }

        private static void SetConnections(JObject json, IReadOnlyDictionary<int, List<IConnection>> connections, IReadOnlyDictionary<int, IRoom> rooms)
        {
            if (!json.ContainsKey("connections")) return;
            
            foreach (var jConnection in json["connections"].Children<JObject>())
            {
                var convertLocation = new Dictionary<string, Direction>
                {
                    {"NORTH", Direction.Top},
                    {"EAST", Direction.Right},
                    {"SOUTH", Direction.Bottom},
                    {"WEST", Direction.Left},
                };

                var actualConnections = jConnection.Properties()
                    .Where(jp => convertLocation.ContainsKey(jp.Name)).ToArray();

                var roomId1 = actualConnections[0].Value.Value<int>();
                var location1 = convertLocation[actualConnections[0].Name];

                var roomId2 = actualConnections[1].Value.Value<int>();
                var location2 = convertLocation[actualConnections[1].Name];

                IDoor connectionDoor = null;

                if (jConnection.ContainsKey("door"))
                {
                    var doorJToken = jConnection["door"];

                    switch (doorJToken["type"].Value<string>())
                    {
                        case "colored":
                        {
                            var color = Color.FromName(doorJToken["color"].Value<string>());

                            connectionDoor = new ColoredDoor(color);
                            break;
                        }
                        case "toggle":
                        {
                            connectionDoor = new ToggleDoor();
                            break;
                        }
                        case "closing gate":
                        {
                            connectionDoor = new ClosingDoor();
                            break;
                        }
                    }
                }

                var conn1 = new Connection(rooms[roomId1], location1, connectionDoor);
                var conn2 = new Connection(rooms[roomId2], location2, connectionDoor);

                conn1.Destination = conn2;
                conn2.Destination = conn1;

                connections[roomId1].Add(conn1);
                connections[roomId2].Add(conn2);
            }
        }
    }

    public class JsonException : Exception
    {
        public JsonException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
