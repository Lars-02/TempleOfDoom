namespace CODE_GameLib.Interfaces
{
    public interface IEntityLocation : IBaseObservable<IEntityLocation>
    {
        public IRoom Room { get; }
        public int X { get; }
        public int Y { get; }

        public bool Update(IRoom room, int x, int y);
    }
}