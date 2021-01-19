using CODE_GameLib.Entity;

namespace CODE_GameLib.RoomObjects.Decorators
{
    public class TeleportEntityObjectDecorator : BaseRoomObjectDecorator
    {
        private readonly ILocation _destination;

        public TeleportEntityObjectDecorator(IRoomObject decorator, ILocation destination) : base(decorator)
        {
            _destination = destination;
        }

        public override void Interact(IEntity entity)
        {
            base.Interact(entity);
            entity.Teleport(_destination);
        }
    }
}