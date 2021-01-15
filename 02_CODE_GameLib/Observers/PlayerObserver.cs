using System;
using System.Linq;
using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items.Wearable;

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
            if (entity.Died)
                _game.Destroy(false);
            if (!(entity is IPlayer player))
                return;
            if (player.Inventory.Count(wearable => wearable is ISankaraStone) >= 5 ||
                (player.Cheats.Contains(Cheat.OneMoreStone) && player.Inventory.Last() is ISankaraStone))
                _game.Destroy(true);
        }
    }
}