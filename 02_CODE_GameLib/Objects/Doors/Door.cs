using CODE_GameLib.Objects.Entity;

namespace CODE_GameLib.Objects.Doors
{
    public class Door : IDoor
    {
        public bool Opened { get; set; }

        public virtual bool PassThru(IEntity entity)
        {
            return Opened;
        }
    }

    public interface IDoor
    {
        public bool Opened { get; set; }
        public bool PassThru(IEntity entity);
    }
}