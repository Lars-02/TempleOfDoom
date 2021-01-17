using CODE_GameLib.Doors;
using CODE_GameLib.Enums;

namespace CODE_GameLib
{
    public class Connection : IConnection
    {
        public Connection(IRoom room, Direction direction, IDoor door = null)
        {
            Room = room;
            Direction = direction;
            Door = door;
        }

        public IRoom Room { get; }
        public IConnection Destination { get; set; }
        public Direction Direction { get; }
        public IDoor Door { get; }
    }

    public interface IConnection
    {
        public IRoom Room { get; }
        public IConnection Destination { get; set; }
        public Direction Direction { get; }
        public IDoor Door { get; }
    }
}