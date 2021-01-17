using System;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Objects;

namespace CODE_GameLib.Interfaces
{
    public interface IGame
    {
        public bool Quit { get; }
        public bool Won { get; }
        public IPlayer Player { get; }
        public event EventHandler<Game> Updated;
        public void Update();
        public void Tick(TickData tickData);
        public void Destroy(bool winGame);
    }
}