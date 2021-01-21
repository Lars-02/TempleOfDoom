using CODE_GameLib.Entity;

namespace CODE_GameLib.RoomObjects.BoobyTraps
{
    public class DisappearingTrap : BoobyTrap, IDisappearingTrap
    {
        private readonly IRoom _room;

        public DisappearingTrap(ILocation location, int damage) :
            base(new RoomObject(location.X, location.Y), damage)
        {
            _room = location.Room;
        }

        public override void Interact(IEntity entity)
        {
            base.Interact(entity);
            _room.RemoveRoomObject(this);
        }
    }

    public interface IDisappearingTrap
    {
    }
}