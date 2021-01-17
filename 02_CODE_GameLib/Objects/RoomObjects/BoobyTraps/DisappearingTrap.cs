using CODE_GameLib.Interfaces.RoomObjects.BoobyTraps;

namespace CODE_GameLib.Objects.RoomObjects
{
    public class DisappearingTrap : BoobyTrap, IDisappearingTrap
    {
        public DisappearingTrap(int x, int y, int damage) : base(x, y, damage)
        {
        }
    }
}