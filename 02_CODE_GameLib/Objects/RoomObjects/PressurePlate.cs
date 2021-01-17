using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.RoomObjects;

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
}