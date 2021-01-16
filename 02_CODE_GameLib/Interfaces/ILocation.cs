using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib.Interfaces
{
    public interface ILocation : IBaseObservable<ILocation>
    {
        public IRoom Room { get; }
        public int X { get; }
        public int Y { get; }

        public bool SetLocation(ILocation location);
        public IItem GetItem();
    }
}