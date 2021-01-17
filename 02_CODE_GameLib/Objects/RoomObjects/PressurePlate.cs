using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Objects.Doors;

namespace CODE_GameLib.Objects.RoomObjects
{
    public class PressurePlate : RoomObject, IPressurePlate
    {
        public PressurePlate(int x, int y) : base(x, y)
        {
        }

        public void ActivatePressurePlate(IEnumerable<IConnection> connections)
        {
            foreach (var door in connections.Select(conn => conn.Door))
                if (door is IToggleDoor toggleDoor)
                    toggleDoor.ActivateToggleDoor();
        }
    }

    public interface IPressurePlate : IRoomObject
    {
        public void ActivatePressurePlate(IEnumerable<IConnection> connections);
    }
}