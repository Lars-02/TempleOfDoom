using System;
using CODE_GameLib.Entity;

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
        ///     This will get updated when the location is updated.
        ///     When this happens the method will look for any RoomObjects or Entity's in it's place.
        ///     If it finds any it preforms an action for that item.
        /// </summary>
        /// <param name="location"> Updated location from an entity</param>
        public void OnNext(ILocation location)
        {
            if (_entity is IPlayer player && location.IsEnemy(_game.Enemies))
                player.ReceiveDamage(1);

            // Get roomObject if there is one
            var roomObject = location.GetRoomObject();

            if (roomObject == null)
                return;

            roomObject.Interact(_entity);
        }
    }
}