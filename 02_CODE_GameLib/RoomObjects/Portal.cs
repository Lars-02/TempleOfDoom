using CODE_GameLib.Entity;

namespace CODE_GameLib.RoomObjects
{
    public class Portal : RoomObject, IPortal
    {
        public Portal(int x, int y, ILocation destination) : base(x, y)
        {
            Destination = destination;
        }

        private ILocation Destination { get; }

        public void UsePortal(IEntity entity)
        {
            entity.Teleport(Destination);
        }
    }

    public interface IPortal : IRoomObject
    {
        public void UsePortal(IEntity entity);
    }
}