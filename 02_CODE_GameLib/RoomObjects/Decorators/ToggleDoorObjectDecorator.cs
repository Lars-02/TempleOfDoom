using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Doors;
using CODE_GameLib.Entity;

namespace CODE_GameLib.RoomObjects.Decorators
{
    public class ToggleDoorObjectDecorator : BaseRoomObjectDecorator
    {
        private readonly IEnumerable<IConnection> _connections;

        public ToggleDoorObjectDecorator(IRoomObject decorator, IEnumerable<IConnection> connections) : base(decorator)
        {
            _connections = connections;
        }

        public override void Interact(IEntity entity)
        {
            base.Interact(entity);
            foreach (var door in _connections.Select(conn => conn.Door))
                if (door is IToggleDoor toggleDoor)
                    toggleDoor.ActivateToggleDoor();
        }
    }
}