using System;
using System.Linq;
using CODE_GameLib.Entity;
using CODE_GameLib.Enums;
using CODE_GameLib.RoomObjects.Wearable;

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
        /// This method is called when the player is updated. Since a player is an entity.
        /// The if statement checks if the player collected 5 or more stone's,
        /// or one more stone is collected while the cheat OneMoreStone is enabled.
        /// If true the player wins. Also check the entity died
        /// </summary>
        /// <param name="entity"> The entity that changed </param>
        public void OnNext(IEntity entity)
        {
            if (!(entity is IPlayer player))
                return;
            
            if (entity.Died)
            {
                _game.Destroy(false);
                return;
            }
            
            if (player.Inventory.Count(wearable => wearable is ISankaraStone) >= 5 ||
                player.IsCheatEnabled(Cheat.OneMoreStone) && player.Inventory.LastOrDefault() is ISankaraStone)
                _game.Destroy(true);
        }
    }
}