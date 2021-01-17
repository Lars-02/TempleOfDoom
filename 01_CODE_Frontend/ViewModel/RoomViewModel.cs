using System;
using System.Linq;
using CODE_GameLib.Objects;
using CODE_GameLib.Objects.Entity;

namespace CODE_Frontend.ViewModel
{
    public class RoomViewModel
    {
        private readonly ConsoleText[,] _grid;
        private readonly IPlayer _player;
        private readonly IRoom _room;

        public RoomViewModel(IRoom room, IPlayer player)
        {
            _room = room;
            _player = player;
            _grid = new ConsoleText[room.Width, room.Height];
        }

        public ConsoleText[,] GetGrid()
        {
            InitializeGrid();

            // Set connections
            foreach (var connection in _room.Connections.Select(
                connection => new ConnectionViewModel(connection, _room)))
                _grid[connection.X, connection.Y] = connection.View;

            // Set items
            foreach (var item in _room.Items.Select(item => new ItemViewModel(item)))
                _grid[item.X, item.Y] = item.View;

            // Set player
            var playerViewModel = new PlayerViewModel(_player);
            _grid[playerViewModel.X, playerViewModel.Y] = PlayerViewModel.View;

            return _grid;
        }

        private void InitializeGrid()
        {
            var wallConsoleText = new ConsoleText("#", ConsoleColor.Yellow);

            for (var col = 0; col < _grid.GetLength(0); col++)
            {
                _grid[col, 0] = wallConsoleText;
                _grid[col, _grid.GetLength(1) - 1] = wallConsoleText;

                var consoleText = new ConsoleText(" ");

                if (col == 0 || col == _grid.GetLength(0) - 1)
                    consoleText = wallConsoleText;

                for (var row = 1; row < _grid.GetLength(1) - 1; row++)
                    _grid[col, row] = consoleText;
            }
        }
    }
}