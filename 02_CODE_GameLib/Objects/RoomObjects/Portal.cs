using CODE_GameLib.Objects.Entity;

namespace CODE_GameLib.Objects.RoomObjects
{
    public class Portal : RoomObject, IPortal
    {
        public Portal(int x, int y, ILocation destination) : base(x, y)
        {
            Destination = destination;
        }

        public ILocation Destination { get; }

        public bool UsePortal(IEntity entity)
        {
            return entity.Teleport(Destination);
        }
    }

    public interface IPortal : IRoomObject
    {
        ILocation Destination { get; }

        public bool UsePortal(IEntity entity);
    }
}