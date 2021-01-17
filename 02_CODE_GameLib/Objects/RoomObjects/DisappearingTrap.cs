using CODE_GameLib.Interfaces.RoomObjects.BoobyTraps;

namespace CODE_GameLib.Objects.RoomObjects
{
    public class DisappearingTrap : IDisappearingTrap
    {
        public DisappearingTrap(int x, int y, int damage)
        {
            X = x;
            Y = y;
            Damage = damage;
        }

        public int X { get; }
        public int Y { get; }
        public int Damage { get; }
    }
}