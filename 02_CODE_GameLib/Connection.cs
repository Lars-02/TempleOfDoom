using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;

namespace CODE_GameLib
{
    public class Connection : IConnection
    {
        public IRoom Room { get; }
        public IConnection Destination { get; set; }
        public Direction Direction { get; }
        public IDoor Door { get; }

        public Connection(IRoom room, Direction direction, IDoor door = null)
        {
            Room = room;
            Direction = direction;
            Door = door;
        }
    }
}
