using System;
using CODE_GameLib;
using CODE_GameLib.Enums;

namespace CODE_Frontend.ViewModel
{
    public class ConnectionViewModel
    {
        private readonly IConnection _connection;

        public ConnectionViewModel(IConnection connection, IRoom room)
        {
            _connection = connection;

            switch (connection.Direction)
            {
                case Direction.North:
                case Direction.South:
                    X = (room.Width + 1) / 2 - 1;
                    Y = connection.Direction == Direction.North ? 0 : room.Height - 1;
                    break;
                case Direction.East:
                case Direction.West:
                    X = connection.Direction == Direction.West ? 0 : room.Width - 1;
                    Y = (room.Height + 1) / 2 - 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public int X { get; }
        public int Y { get; }
        public ConsoleText View => new DoorViewModel(_connection.Door, _connection.Direction).View;
    }
}