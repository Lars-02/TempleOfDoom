using CODE_GameLib.RoomObjects.Decorators;

namespace CODE_GameLib.RoomObjects.BoobyTraps
{
    public class BoobyTrap : BaseRoomObjectDecorator, IBoobyTrap
    {
        public BoobyTrap(int x, int y, int damage) : base(
            new DamageEntityObjectDecorator(new RoomObject(x, y), damage))
        {
        }

        protected BoobyTrap(IRoomObject decorator, int damage) : base(
            new DamageEntityObjectDecorator(decorator, damage))
        {
        }
    }

    public interface IBoobyTrap
    {
    }
}