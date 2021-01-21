using System;
using CODE_GameLib.Entity;

namespace CODE_Frontend.ViewModel
{
    public class PlayerViewModel
    {
        private readonly IEntity _entity;

        public PlayerViewModel(IEntity entity)
        {
            _entity = entity;
        }

        public int X => _entity.Location.X;
        public int Y => _entity.Location.Y;
        public ConsoleText View => _entity is IPlayer ? new ConsoleText("X") : new ConsoleText("E", ConsoleColor.Red);
    }
}