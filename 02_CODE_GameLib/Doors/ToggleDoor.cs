using CODE_GameLib.Interfaces.Doors;

namespace CODE_GameLib.Doors
{
    public class ToggleDoor : Door, IToggleDoor
    {
        public void ActivateToggleDoor()
        { 
            Opened = !Opened;
        }
    }
}
