using CODE_GameLib.Doors;
using CODE_GameLib.Enums;

namespace CODE_Frontend.ViewModel
{
    public class DoorViewModel
    {
        private readonly Direction _direction;
        private readonly IDoor _door;

        public DoorViewModel(IDoor door, Direction direction)
        {
            _door = door;
            _direction = direction;
        }

        public ConsoleText View => GetDoorConsoleText(_door, _direction);

        private static ConsoleText GetDoorConsoleText(IDoor door, Direction direction)
        {
            switch (door)
            {
                case IClosingDoor _:
                    return new ConsoleText("⋂");
                case IToggleDoor _:
                    return new ConsoleText("⊥");
                case IColoredDoor coloredDoor:
                {
                    var consoleText = new ConsoleText("|", coloredDoor.Color);

                    if (direction == Direction.North || direction == Direction.South)
                        consoleText.Text = "−";

                    return consoleText;
                }
                default:
                    return new ConsoleText(" ");
            }
        }
    }
}