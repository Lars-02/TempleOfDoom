using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Interfaces.Items
{
    public interface IPortal : IItem
    {
        ILocation Destination { get; }

        public bool UsePortal(IEntity entity);
    }
}