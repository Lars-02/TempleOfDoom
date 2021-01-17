using CODE_GameLib.Interfaces.RoomObjects.Wearable;

namespace CODE_GameLib.Objects.RoomObjects
{
    public class SankaraStone : ISankaraStone
    {
        public SankaraStone(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }
}