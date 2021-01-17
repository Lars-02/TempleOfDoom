using System;
using System.Linq;
using CODE_GameLib.Entity;
using CODE_GameLib.Enums;
using CODE_GameLib.RoomObjects.Wearable;

namespace CODE_GameLib.Observers
{
    public class PlayerObserver : IObserver<IPlayer>
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

        /// <summary>
        /// This method is called when the player is updated. Since a player is an entity there is only one check.
        /// The if statement checks if the player collected 5 or more stone's,
        /// or one more stone is collected while the cheat OneMoreStone is enabled.
        /// If true the player wins.
        /// </summary>
        /// <param name="player"> The update player </param>
        public void OnNext(IPlayer player)
        {
            if (player.Inventory.Count(wearable => wearable is ISankaraStone) >= 5 ||
                player.IsCheatEnabled(Cheat.OneMoreStone) && player.Inventory.LastOrDefault() is ISankaraStone)
                _game.Destroy(true);
        }
    }
}