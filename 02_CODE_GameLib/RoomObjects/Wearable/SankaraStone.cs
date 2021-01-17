namespace CODE_GameLib.RoomObjects.Wearable
{
    public class SankaraStone : RoomObject, ISankaraStone
    {
        public SankaraStone(int x, int y) : base(x, y)
        {
        }
    }

    public interface ISankaraStone : IWearable
    {
    }
}