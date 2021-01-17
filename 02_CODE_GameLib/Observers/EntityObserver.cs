using System;
using CODE_GameLib.Entity;

namespace CODE_GameLib.Observers
{
    public class EntityObserver : IObserver<IEntity>
    {
        private readonly IGame _game;

        public EntityObserver(IGame game)
        {
            _game = game;
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
        /// This method checks if the entity died because it has less then 1 live.
        /// </summary>
        /// <param name="entity"> The entity that changed </param>
        public void OnNext(IEntity entity)
        {
            if (entity.Died)
                _game.Destroy(false);
        }
    }
}