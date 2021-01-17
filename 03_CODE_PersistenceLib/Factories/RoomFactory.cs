using System;
using System.Collections.Generic;
using System.Linq;
using CODE_GameLib;
using CODE_GameLib.RoomObjects;
using Newtonsoft.Json.Linq;

namespace CODE_PersistenceLib.Factories
{
    public static class RoomFactory
    {
        public static IRoom CreateRoom(JObject roomJObject, IDictionary<int, List<IConnection>> connections,
            out int roomId)
        {
            roomId = roomJObject["id"].Value<int>();

            connections.Add(roomId, new List<IConnection>());

            var items = GetItemsForRoom(roomJObject);

            var width = roomJObject["width"].Value<int>();
            var height = roomJObject["height"].Value<int>();

            if (height < 3 || height > 50)
                throw new ArgumentException("Height must be between 3 and 50");
            if (width < 3 || width > 50)
                throw new ArgumentException("Width must be between 3 and 50");

            if (height % 2 == 0)
                throw new ArgumentException("Height must be even");
            if (width % 2 == 0)
                throw new ArgumentException("Width must be even");

            return new Room(width, height, items, connections[roomId]);
        }

        private static List<IRoomObject> GetItemsForRoom(JObject roomJObject)
        {
            var items = new List<IRoomObject>();

            if (roomJObject.ContainsKey("items"))
                items.AddRange(roomJObject["items"].Select(ItemFactory.CreateItem));
            if (roomJObject.ContainsKey("specialFloorTiles"))
                items.AddRange(roomJObject["specialFloorTiles"].Select(ItemFactory.CreateItem));

            return items;
        }
    }
}