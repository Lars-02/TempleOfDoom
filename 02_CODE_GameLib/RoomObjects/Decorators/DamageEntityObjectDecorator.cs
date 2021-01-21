using CODE_GameLib.Entity;

namespace CODE_GameLib.RoomObjects.Decorators
{
    public class DamageEntityObjectDecorator : BaseRoomObjectDecorator
    {
        private readonly int _damage;

        public DamageEntityObjectDecorator(IRoomObject decorator, int damage) : base(decorator)
        {
            _damage = damage;
        }

        public override void Interact(IEntity entity)
        {
            base.Interact(entity);
            entity.ReceiveDamage(_damage);
        }
    }
}