using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.RoomObjects;

namespace CODE_GameLib.Objects.RoomObjects
{
    public class PressurePlate : IPressurePlate
    {
        public PressurePlate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public void ActivatePressurePlate(IEnumerable<IConnection> connections)
        {
            foreach (var door in connections.Select(conn => conn.Door))
                if (door is IToggleDoor toggleDoor)
                    toggleDoor.ActivateToggleDoor();
        }
    }
}