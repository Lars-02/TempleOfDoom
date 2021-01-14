using CODE_GameLib;
using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces.Doors;

namespace CODE_Frontend.ViewModel
{
    public class DoorViewModel
    {
        private readonly IDoor _door;
        private readonly Direction _direction;

        public ConsoleText View => GetDoorConsoleText(_door, _direction);

        public DoorViewModel(IDoor door, Direction direction)
        {
            _door = door;
            _direction = direction;
        }
        
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
                    var consoleText = new ConsoleText("|", Util.ColorToConsoleColor(coloredDoor.Color));
                    
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
