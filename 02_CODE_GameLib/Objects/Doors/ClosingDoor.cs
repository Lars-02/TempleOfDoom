using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Objects.Doors
{
    public class ClosingDoor : Door, IClosingDoor
    {
        public ClosingDoor()
        {
            Opened = true;
        }

        public override bool PassThru(IEntity entity)
        {
            if (!Opened) return false;
            Opened = false;
            return true;
        }
    }
}