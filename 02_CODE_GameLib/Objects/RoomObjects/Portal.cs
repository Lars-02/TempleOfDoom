using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.RoomObjects;

namespace CODE_GameLib.Objects.RoomObjects
{
    public class Portal : RoomObject, IPortal
    {
        public Portal(int x, int y, ILocation destination) : base(x, y) => Destination = destination;
        
        public ILocation Destination { get; }

        public bool UsePortal(IEntity entity)
        {
            return entity.Teleport(Destination);
        }
    }
}