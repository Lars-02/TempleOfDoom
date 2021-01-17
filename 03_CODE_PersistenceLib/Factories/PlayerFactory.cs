using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Objects.Entity;
using Newtonsoft.Json.Linq;

namespace CODE_PersistenceLib.Factories
{
    public static class PlayerFactory
    {
        public static IPlayer CreatePlayer(JToken playerJToken, ILocation location)
        {
            return new Player(
                playerJToken["lives"].Value<int>(),
                location
            );
        }
    }
}