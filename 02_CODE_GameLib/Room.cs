using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib
{
    public class Room : IRoom
    {
        public int Width { get; }
        public int Height { get; }
        public List<IItem> Items { get; }
        public IEnumerable<IConnection> Connections { get; }

        public Room(int width, int height, List<IItem> items, IEnumerable<IConnection> connections)
        {
            Width = width;
            Height = height;
            Items = items;
            Connections = connections;
        }
        
        public bool RemoveItem(IItem item) => Items.Remove(item);

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

            if (connection?.Door != null && !connection.Door.CanPassThru(entity))
                return null;

            return connection?.Destination;
        }

        private static (int, int) GetDestinationXy(IConnection destination)
        {
            if (destination.Direction == Direction.North || destination.Direction == Direction.South)
                return ((destination.Room.Width + 1) / 2 - 1,
                    destination.Direction == Direction.South ? 0 : destination.Room.Height - 1);
            return (destination.Direction == Direction.West ? 0 : destination.Room.Width - 1,
                (destination.Room.Height + 1) / 2 - 1);
        }

        private bool IsWall(int x, int y) => x < 1 || y < 1 || x > Width - 2 || y > Height - 2;

        private bool IsCenterOfWall(int x, int y) =>
            IsWall(x, y) && (x == (Width + 1) / 2 - 1 || y == (Height + 1) / 2 - 1);
    }
}