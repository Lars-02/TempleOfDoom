using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Observers;

namespace CODE_GameLib.Entity
{
    public class Entity : BaseObservable<IEntity>, IEntity
    {
        public IEntityLocation Location { get; }
        public int Lives { get; }
        public bool Died { get; }
        public bool Move(Direction direction)
        {
            throw new System.NotImplementedException();
        }

        public bool ReceiveDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}