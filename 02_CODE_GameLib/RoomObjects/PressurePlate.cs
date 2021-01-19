using System.Collections.Generic;
using CODE_GameLib.RoomObjects.Decorators;

namespace CODE_GameLib.RoomObjects
{
    public class PressurePlate : BaseRoomObjectDecorator, IPressurePlate
    {
        public PressurePlate(int x, int y, IEnumerable<IConnection> connections) : base(
            new OnlyForPlayObjectDecorator(new ToggleDoorObjectDecorator(new RoomObject(x, y), connections)))
        {
        }
    }

    public interface IPressurePlate
    {
    }
}