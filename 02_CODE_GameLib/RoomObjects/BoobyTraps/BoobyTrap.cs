namespace CODE_GameLib.RoomObjects.BoobyTraps
{
    public class BoobyTrap : RoomObject, IBoobyTrap
    {
        public BoobyTrap(int x, int y, int damage) : base(x, y)
        {
            Damage = damage;
        }

        public int Damage { get; }
    }

    public interface IBoobyTrap : IRoomObject
    {
        public int Damage { get; }
    }
}