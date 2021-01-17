using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Interfaces.Doors
{
    public interface IDoor
    {
        public bool Opened { get; set; }
        public bool PassThru(IEntity entity);
    }
}
