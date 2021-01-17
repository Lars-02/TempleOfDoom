using System.Collections.Generic;
using CODE_GameLib;
using CODE_GameLib.Entity;

namespace CODE_PersistenceLib.Factories
{
    public static class GameFactory
    {
        public static IGame CreateGame(IPlayer player, List<IEnemy> enemies)
        {
            return new Game(player, enemies);
        }
    }
}