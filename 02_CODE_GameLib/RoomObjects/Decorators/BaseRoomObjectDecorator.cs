using CODE_GameLib.Entity;

namespace CODE_GameLib.RoomObjects.Decorators
{
    public abstract class BaseRoomObjectDecorator : RoomObject
    {
        private readonly IRoomObject _decorator;

        protected BaseRoomObjectDecorator(IRoomObject decorator) : base(decorator.X, decorator.Y)
        {
            _decorator = decorator;
        }


        public override void Interact(IEntity entity)
        {
            _decorator.Interact(entity);
        }
    }
}