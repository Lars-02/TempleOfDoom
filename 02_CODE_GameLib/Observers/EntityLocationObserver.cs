using System;
using CODE_GameLib.Entity;
using CODE_GameLib.RoomObjects;
using CODE_GameLib.RoomObjects.BoobyTraps;
using CODE_GameLib.RoomObjects.Wearable;

namespace CODE_GameLib.Observers
{
    public class EntityLocationObserver : IObserver<ILocation>
    {
        private readonly IEntity _entity;
        private readonly IGame _game;

        public EntityLocationObserver(IGame game, IEntity entity)
        {
            _game = game;
            _entity = entity;
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(ILocation location)
        {
            var item = location.GetItem();

            switch (item)
            {
                case IBoobyTrap boobyTrap:
                    _entity.ReceiveDamage(boobyTrap.Damage);
                    break;
                case IConveyorBelt conveyorBelt:
                    conveyorBelt.UseConveyorBelt(_entity);
                    break;
                case IPortal portal:
                    portal.UsePortal(_entity);
                    break;
                default:
                    if (!(_entity is IPlayer player))
                        break;
                    switch (item)
                    {
                        case IWearable wearable:
                            player.AddToInventory(wearable);
                            break;
                        case IPressurePlate pressurePlate:
                            pressurePlate.ActivatePressurePlate(location.Room.Connections);
                            break;
                    }

                    break;
            }

            if (item is IWearable || item is IDisappearingTrap)
                location.Room.RemoveItem(item);
        }
    }
}