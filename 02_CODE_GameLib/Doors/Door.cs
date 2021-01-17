using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Doors
{
    public class Door : IDoor
    {
        public bool Opened { get; set; }
        public virtual bool PassThru(IEntity entity)
        {
            return Opened;
        }
    }
}