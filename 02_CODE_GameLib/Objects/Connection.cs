using CODE_GameLib.Enums;
using CODE_GameLib.Objects.Doors;

namespace CODE_GameLib.Objects
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