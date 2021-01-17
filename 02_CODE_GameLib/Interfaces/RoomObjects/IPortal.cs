using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Interfaces.RoomObjects
{
    public interface IPortal : IRoomObject
    {
        ILocation Destination { get; }

        public bool UsePortal(IEntity entity);
    }
}