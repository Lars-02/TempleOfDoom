using CODE_GameLib.Enums;

namespace CODE_GameLib.Objects
{
    public class TickData
    {
        public Direction? MovePlayer { get; set; }

        public Cheat? ToggleCheat { get; set; }
        public bool Quit { get; set; }

        public bool Shoot { get; set; }
    }
}