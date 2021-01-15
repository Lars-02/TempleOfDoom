namespace CODE_GameLib.Interfaces.Items
{
    public interface ILocation
    {
        IRoom Room { get; }
        public int X { get; }
        public int Y { get; }
    }
}