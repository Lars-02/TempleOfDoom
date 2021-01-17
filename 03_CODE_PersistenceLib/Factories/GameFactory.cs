﻿using CODE_GameLib;
using CODE_GameLib.Entity;

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