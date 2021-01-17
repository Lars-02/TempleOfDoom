using System.Collections.Generic;

namespace CODE_GameLib.Interfaces.Items
{
    public interface IPressurePlate : IItem
    {
        public void ActivatePressurePlate(IEnumerable<IConnection> connections);
    }
}
