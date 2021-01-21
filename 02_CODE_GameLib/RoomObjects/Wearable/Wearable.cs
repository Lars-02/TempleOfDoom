using CODE_GameLib.Entity;
using CODE_GameLib.RoomObjects.Decorators;

namespace CODE_GameLib.RoomObjects.Wearable
{
    public class Wearable : BaseRoomObjectDecorator, IWearable
    {
        private readonly IRoom _room;

        public Wearable(IRoomObject decorator, IRoom room) : base(decorator)
        {
            _room = room;
        }

        public override void Interact(IEntity entity)
        {
            base.Interact(entity);
            var player = entity as IPlayer;
            player?.AddToInventory(this);
            _room.RemoveRoomObject(this);
        }
    }

    public interface IWearable
    {
    }
}