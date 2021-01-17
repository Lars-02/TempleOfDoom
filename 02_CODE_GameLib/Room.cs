using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Doors;
using CODE_GameLib.Entity;
using CODE_GameLib.Enums;
using CODE_GameLib.RoomObjects;

namespace CODE_GameLib
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

            var destination = GetDestinationRoom(direction, entity);

            if (destination == null)
                return null;

            var (x, y) = GetCoordinates(direction, destination);

            return new Location(destination, x, y);
        }

        private IRoom GetDestinationRoom(Direction direction, IEntity entity)
        {
            if (Connections.All(conn => conn.Direction != direction))
                return null;

            var connection = Connections.FirstOrDefault(conn => conn.Direction == direction);

            if (connection?.Door == null || connection.Door.PassThru(entity)) return connection?.Room;

            if (connection.Door is IClosingDoor && entity is IPlayer player && player.IsCheatEnabled(Cheat.DoorPortal))
                player.Teleport(player.StartLocation);
            return null;
        }

        private static (int, int) GetCoordinates(Direction origin, IRoom destination)
        {
            if (origin == Direction.North || origin == Direction.South)
                return ((destination.Width + 1) / 2 - 1,
                    origin == Direction.South ? 0 : destination.Height - 1);
            return (origin == Direction.East ? 0 : destination.Width - 1,
                (destination.Height + 1) / 2 - 1);
        }

        public bool IsWall(int x, int y)
        {
            return x < 1 || y < 1 || x > Width - 2 || y > Height - 2;
        }

        private bool IsCenterOfWall(int x, int y)
        {
            return IsWall(x, y) && (x == (Width + 1) / 2 - 1 || y == (Height + 1) / 2 - 1);
        }
    }

    public interface IRoom
    {
        public int Width { get; }
        public int Height { get; }
        public List<IRoomObject> Items { get; }
        public IEnumerable<IConnection> Connections { get; }

        public ILocation GetDestination(int targetX, int targetY, Direction direction, IEntity entity);
        public bool RemoveItem(IRoomObject roomObject);
        public bool IsWall(int x, int y);
    }
}