namespace CODE_GameLib.Objects.RoomObjects.BoobyTraps
{
    public class DisappearingTrap : BoobyTrap, IDisappearingTrap
    {
        public DisappearingTrap(int x, int y, int damage) : base(x, y, damage)
        {
        }
    }

    public interface IDisappearingTrap : IBoobyTrap
    {
    }
}