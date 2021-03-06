using CODE_GameLib.Entity;

namespace CODE_GameLib.Doors
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

    public interface IClosingDoor : IDoor
    {
    }
}