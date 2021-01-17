using CODE_GameLib.Objects;
using CODE_GameLib.Objects.Entity;

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