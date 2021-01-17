using System;
using System.Collections.Generic;
using CODE_PersistenceLib;

namespace CODE_Frontend
{
    internal static class Program
    {
        // Which gameFile to use
        private const int UseGameFile = 1;

        // All included levels
        private static readonly string[] GameFiles =
        {
            "./Levels/TempleOfDoom.json", 
            "./Levels/TempleOfDoom_Extended_B.json", 
            "./Levels/TempleOfDoom_Test_Enemy_Conveyor_Belt.json", 
            "./Levels/TempleOfDoom_Test_Enemy_Conveyor_Belt.json"
        };

        private static void Main()
        {
            while (true)
            {
                var game = GameReader.Read(GameFiles[UseGameFile]);

                var gameView = new GameView();
                game.Updated += (uSender, uGame) => gameView.Update(uGame);

                gameView.Update(game);

                while (!game.Quit)
                {
                    var key = Console.ReadKey().Key;
                    Console.Write("\b");
                    game.Tick(Input.HandleKey(key));
                }

                Console.WriteLine("Please hit any key to restart or escape to quit...");
                var closeKey = Console.ReadKey().Key;
                if (closeKey != ConsoleKey.Escape) continue;
                Console.WriteLine("Quitting game, goodbye!");
                break;
            }
        }
    }
}