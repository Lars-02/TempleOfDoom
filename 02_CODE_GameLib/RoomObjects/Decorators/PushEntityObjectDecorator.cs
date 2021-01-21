using CODE_GameLib.Entity;
using CODE_GameLib.Enums;

namespace CODE_GameLib.RoomObjects.Decorators
{
    public class PushEntityObjectDecorator : BaseRoomObjectDecorator
    {
        private readonly Direction _direction;

        public PushEntityObjectDecorator(IRoomObject decorator, Direction direction) : base(decorator)
        {
            _direction = direction;
        }

        public override void Interact(IEntity entity)
        {
            base.Interact(entity);
            entity.Push(_direction);
        }
    }
}