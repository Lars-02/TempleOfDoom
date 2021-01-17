using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.RoomObjects;

namespace CODE_GameLib.Objects
{
    public class Room : IRoom
    {
        public Room(int width, int height, List<IRoomObject> items, IEnumerable<IConnection> connections)
        {
            Width = width;
            Height = height;
            Items = items;
            Connections = connections;
        }

        public int Width { get; }
        public int Height { get; }
        public List<IRoomObject> Items { get; }
        public IEnumerable<IConnection> Connections { get; }

        public bool RemoveItem(IRoomObject roomObject)
        {
            return Items.Remove(roomObject);
        }

        public ILocation GetDestination(int targetX, int targetY, Direction direction, IEntity entity)
        {
            if (!IsWall(targetX, targetY))
                return new Location(this, targetX, targetY);

            if (!IsCenterOfWall(targetX, targetY))
                return null;

            var destination = GetConnectionDestination(direction, entity);

            return destination == null
                ? null
                : new Location(destination.Room, GetDestinationXy(destination).Item1,
                    GetDestinationXy(destination).Item2);
        }

        private IConnection GetConnectionDestination(Direction direction, IEntity entity)
        {
            if (Connections.All(conn => conn.Direction != direction))
                return null;

            var connection = Connections.FirstOrDefault(conn => conn.Direction == direction);

            if (connection?.Door == null || connection.Door.PassThru(entity)) return connection?.Destination;

            if (connection.Door is IClosingDoor && entity is IPlayer player &&
                player.Cheats.Contains(Cheat.DoorPortal))
                player.Teleport(player.StartLocation);
            return null;
        }

        private static (int, int) GetDestinationXy(IConnection destination)
        {
            if (destination.Direction == Direction.North || destination.Direction == Direction.South)
                return ((destination.Room.Width + 1) / 2 - 1,
                    destination.Direction == Direction.South ? 0 : destination.Room.Height - 1);
            return (destination.Direction == Direction.West ? 0 : destination.Room.Width - 1,
                (destination.Room.Height + 1) / 2 - 1);
        }

        private bool IsWall(int x, int y)
        {
            return x < 1 || y < 1 || x > Width - 2 || y > Height - 2;
        }

        private bool IsCenterOfWall(int x, int y)
        {
            return IsWall(x, y) && (x == (Width + 1) / 2 - 1 || y == (Height + 1) / 2 - 1);
        }
    }
}