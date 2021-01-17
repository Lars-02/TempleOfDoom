using System;
using CODE_PersistenceLib;

namespace CODE_Frontend
{
    internal static class Program
    {
        private static void Main()
        {
            while (true)
            {
                // TODO this is the old game file...
                //var game = GameReader.Read(@"./Levels/TempleOfDoom.json");
                var game = GameReader.Read(@"./Levels/TempleOfDoom_Extended_B.json");

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