using CODE_GameLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using CODE_Frontend.ViewModel;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items.Wearable;

namespace CODE_Frontend.Modules
{
    public class HeaderModule
    {
        private readonly DateTime _startTime;
        private IPlayer _player;

        public HeaderModule()
        {
            _startTime = DateTime.Now;
        }

        private static string Title => "Welcome to Temple of Doom!";

        private string PlayTime => $"Playtime: {DateTime.Now.Subtract(_startTime):hh\\:mm\\:ss}";
        private string SankaraStones => $"Sankara Stones: {_player.Inventory.Count(item => item is ISankaraStone)}";
        private string Lives => $"Lives: {_player.Lives}";

        public IEnumerable<ConsoleText> Render(IGame game)
        {
            _player = game.Player;
            
            yield return new ConsoleText(Title);
            yield return new ConsoleText(Environment.NewLine);
            
            yield return new ConsoleText(Lives);
            yield return new ConsoleText(" - ");
            yield return new ConsoleText(SankaraStones, ConsoleColor.DarkYellow);
            yield return new ConsoleText(" - ");
            yield return new ConsoleText(PlayTime);
            yield return new ConsoleText(Environment.NewLine);

            foreach (var item in GetInventory())
            {
                yield return item;
                yield return new ConsoleText(" ");
            }
            
            yield return new ConsoleText(Environment.NewLine);
            yield return new ConsoleText(GenericModule.HorizontalLine(Console.WindowWidth), ConsoleColor.Gray);
            yield return new ConsoleText(Environment.NewLine);
        }

        private IEnumerable<ConsoleText> GetInventory()
        {
            yield return new ConsoleText("Inventory: ");

            foreach (var item in _player.Inventory.Where(item => !(item is ISankaraStone)))
                yield return new ItemViewModel(item).View;
        }
    }
}
