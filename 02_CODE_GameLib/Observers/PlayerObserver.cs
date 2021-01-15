using System;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Observers
{
    public class PlayerObserver : IObserver<IEntity>
    {

        private readonly IGame _game;

        public PlayerObserver(IGame game)
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

        public void OnNext(IEntity entity)
        {
            if (entity.Died || entity is IPlayer player && player.Won)
                _game.Destroy();
        }
    }
}