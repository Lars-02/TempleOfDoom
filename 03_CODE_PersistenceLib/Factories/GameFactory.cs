using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Objects;

namespace CODE_PersistenceLib.Factories
{
    public static class GameFactory
    {
        public static IGame CreateGame(IPlayer player)
        {
            return new Game(player);
        }
    }
}