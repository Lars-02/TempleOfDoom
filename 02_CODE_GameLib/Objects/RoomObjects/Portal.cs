using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.RoomObjects;

namespace CODE_GameLib.Objects.RoomObjects
{
    public class Portal : IPortal
    {
        public Portal(int x, int y, ILocation destination)
        {
            Destination = destination;
            Y = y;
            X = x;
        }

        public int X { get; }
        public int Y { get; }
        public ILocation Destination { get; }

        public bool UsePortal(IEntity entity)
        {
            return entity.Teleport(Destination);
        }
    }
}