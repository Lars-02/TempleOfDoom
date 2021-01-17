using System.Collections.Generic;

namespace CODE_GameLib.Interfaces.RoomObjects
{
    public interface IPressurePlate : IRoomObject
    {
        public void ActivatePressurePlate(IEnumerable<IConnection> connections);
    }
}