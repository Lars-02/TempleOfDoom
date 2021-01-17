using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib.Items
{
    public class PressurePlate : IPressurePlate
    {
        public int X { get; }
        public int Y { get; }

        public PressurePlate(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public void ActivatePressurePlate(IEnumerable<IConnection> connections)
        {
            foreach (var door in connections.Select(conn => conn.Door))
                if (door is IToggleDoor toggleDoor)
                    toggleDoor.ActivateToggleDoor();
        }
    }
}
