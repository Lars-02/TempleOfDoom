using CODE_GameLib.Entity;

namespace CODE_GameLib.RoomObjects.Decorators
{
    public class OnlyForPlayObjectDecorator : BaseRoomObjectDecorator
    {
        public OnlyForPlayObjectDecorator(IRoomObject decorator) : base(decorator)
        {
        }

        public override void Interact(IEntity entity)
        {
            if (entity is IPlayer)
                base.Interact(entity);
        }
    }
}