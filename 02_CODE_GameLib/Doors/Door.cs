using CODE_GameLib.Entity;

namespace CODE_GameLib.Doors
{
    public class Door : IDoor
    {
        protected bool Opened { get; set; }

        public virtual bool PassThru(IEntity entity)
        {
            return Opened;
        }
    }

    public interface IDoor
    {
        public bool PassThru(IEntity entity);
    }
}