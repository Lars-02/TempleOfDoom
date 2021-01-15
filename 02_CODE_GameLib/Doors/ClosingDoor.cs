using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Doors
{
    public class ClosingDoor : IClosingDoor
    {
        public bool Opened { get; set; }

        public ClosingDoor()
        {
            Opened = true;
        }

        public bool CanPassThru(IEntity entity)
        {
            if (!Opened) return false;

            Opened = false;

            return true;
        }
    }
}
