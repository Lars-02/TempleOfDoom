using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Doors
{
    public class ToggleDoor : IToggleDoor
    {
        public bool Opened { get; set; }

        public bool PassThru(IPlayer player)
        {
            return Opened;
        }
    }
}
