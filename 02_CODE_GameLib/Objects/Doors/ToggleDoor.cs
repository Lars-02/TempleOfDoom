namespace CODE_GameLib.Objects.Doors
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