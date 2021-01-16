using CODE_GameLib.Interfaces.Items;
using System.Collections.Generic;
using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Interfaces
{
    public interface IRoom
    {
        public int Width { get; }
        public int Height { get; }
        public List<IItem> Items { get; }
        public IEnumerable<IConnection> Connections { get; }

        public ILocation GetDestination(int targetX, int targetY, Direction direction, IEntity entity);
        public bool RemoveItem(IItem item);

    }
}
