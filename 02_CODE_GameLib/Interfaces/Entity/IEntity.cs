using CODE_GameLib.Enums;

namespace CODE_GameLib.Interfaces.Entity
{
    public interface IEntity : IBaseObservable<IEntity>
    {
        public ILocation Location { get; }

        public int Lives { get; }
        
        public bool Died { get; }
        
        public bool Move(Direction direction);
        
        public bool ReceiveDamage(int damage);
    }
}