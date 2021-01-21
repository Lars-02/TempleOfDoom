namespace CODE_GameLib.Doors
{
    public class ToggleDoor : Door, IToggleDoor
    {
        public void ActivateToggleDoor()
        {
            Opened = !Opened;
        }
    }

    public interface IToggleDoor : IDoor
    {
        public void ActivateToggleDoor();
    }
}