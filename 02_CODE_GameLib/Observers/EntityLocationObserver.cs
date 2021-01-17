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

        /// <summary>
        /// This will get updated when the location is updated.
        /// When this happens the method will look for any RoomObjects or Entity's in it's place.
        /// If it finds any it preforms an action for that item. 
        /// </summary>
        /// <param name="location"> Updated location from an entity</param>
        public void OnNext(ILocation location)
        {
            // Get roomObject if there is one
            var roomObject = location.GetRoomObject();
            
            // Get player
            var player = _entity as IPlayer;

            switch (roomObject)
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
                    // Check if there is a player
                    if (player == null)
                        break;
                    switch (roomObject)
                    {
                        case IWearable wearable:
                            player.AddToInventory(wearable);
                            break;
                        case IPressurePlate pressurePlate:
                            pressurePlate.ActivatePressurePlate(location.Room.Connections);
                            break;
                        default:
                            if (location.IsEnemy(_game.Enemies))
                            {
                                player.ReceiveDamage(1);
                                return;
                            }
                            break;
                        }
                    break;
            }
            
            if (roomObject is IWearable || roomObject is IDisappearingTrap)
                location.Room.RemoveItem(roomObject);
        }
    }
}