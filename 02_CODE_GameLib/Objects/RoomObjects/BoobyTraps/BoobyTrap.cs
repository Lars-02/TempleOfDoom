using CODE_GameLib.Interfaces.RoomObjects.BoobyTraps;

namespace CODE_GameLib.Objects.RoomObjects
{
    public class BoobyTrap : RoomObject, IBoobyTrap
    {
        public int Damage { get; }
        
        public BoobyTrap(int x, int y, int damage) : base(x, y) => Damage = damage;
    }
}