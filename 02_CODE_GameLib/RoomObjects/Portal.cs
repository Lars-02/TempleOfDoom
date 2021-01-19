using CODE_GameLib.RoomObjects.Decorators;

namespace CODE_GameLib.RoomObjects
{
    public class Portal : BaseRoomObjectDecorator, IPortal
    {
        public Portal(int x, int y, ILocation destination) : base(
            new TeleportEntityObjectDecorator(new RoomObject(x, y), destination))
        {
        }
    }

    public interface IPortal
    {
    }
}