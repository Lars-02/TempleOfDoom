using CODE_GameLib.Interfaces;
using System;

namespace CODE_GameLib
{
    public class PlayerObserver : IObserver<IPlayer>
    {

        private readonly IGame _game;

        public PlayerObserver(IGame game, IPlayer player)
        {
            _game = game;
            player.Subscribe(this);
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(IPlayer player)
        {
            if (player.Died || player.Won)
                _game.Destroy();
        }
    }
}