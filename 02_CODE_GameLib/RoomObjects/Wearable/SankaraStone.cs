namespace CODE_GameLib.RoomObjects.Wearable
{
    public class SankaraStone : Wearable, ISankaraStone
    {
        public SankaraStone(ILocation location) : base(new RoomObject(location.X, location.Y), location.Room)
        {
        }
    }

    public interface ISankaraStone
    {
    }
}