using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CODE_GameLib;
using CODE_GameLib.Entity;
using CODE_PersistenceLib.Factories;
using Newtonsoft.Json.Linq;

namespace CODE_PersistenceLib
{
    public static class GameReader
    {
        private static Dictionary<int, IRoom> _rooms;
        private static List<IEnemy> _enemies ;

        public static IGame Read(string filePath)
        {
            _rooms = new Dictionary<int, IRoom>();
            _enemies = new List<IEnemy>();
            IPlayer player;

            try
            {
                var json = JObject.Parse(File.ReadAllText(filePath));

                var connections = new Dictionary<int, List<IConnection>>();

                SetRooms(json, connections);
                SetConnections(json, connections);

                var playerJToken = json["player"];
                var playerStartLocation = EntityLocationFactory.CreateEntityLocation(_rooms, playerJToken);
                player = PlayerFactory.CreatePlayer(playerJToken, playerStartLocation);
                
            }
            catch (Exception e)
            {
                throw new JsonException("The provided JSON level file is not valid.", e);
            }

            return GameFactory.CreateGame(player, _enemies);
        }

        private static void SetRooms(JObject json, IDictionary<int, List<IConnection>> connections)
        {
            foreach (var roomJObject in json["rooms"].Children<JObject>())
            {
                var room = RoomFactory.CreateRoom(roomJObject, connections, out var roomId, out var enemies);
                _enemies.AddRange(enemies);
                _rooms.Add(roomId, room);
            }
        }

        private static void SetConnections(JObject json, IReadOnlyDictionary<int, List<IConnection>> connections)
        {
            if (!json.ContainsKey("connections")) return;

            foreach (var jConnection in json["connections"].Children<JObject>())
            {
                if (jConnection.ContainsKey("portal"))
                {
                    PortalFactory.CreatePortal(jConnection, _rooms, out var portal1, out var portalRoomId1,
                        out var portal2, out var portalRoomId2);
                    _rooms.FirstOrDefault(room => room.Key == portalRoomId1).Value.Items.Add(portal1);
                    _rooms.FirstOrDefault(room => room.Key == portalRoomId2).Value.Items.Add(portal2);
                    continue;
                }

                ConnectionFactory.CreateConnection(jConnection, _rooms, out var conn1, out var conn2, out var roomId1,
                    out var roomId2);

                connections[roomId1].Add(conn2);
                connections[roomId2].Add(conn1);
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