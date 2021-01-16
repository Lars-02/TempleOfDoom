using System;
using System.Linq;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Interfaces.Items.BoobyTraps;
using CODE_GameLib.Interfaces.Items.Wearable;

namespace CODE_GameLib.Observers
{
    public class EntityLocationObserver : IObserver<ILocation>
    {
        private readonly IGame _game;
        private readonly IEntity _entity;

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
                        case IPressurePlate _:
                            foreach (var connection in location.Room.Connections.Where(conn => conn.Door is IToggleDoor))
                                connection.Door.Opened = !connection.Door.Opened;
                            break;
                    }
                    break;
            }

            if (item is IWearable || item is IDisappearingTrap)
                location.Room.RemoveItem(item);

            _game.Update();
        }
    }
}