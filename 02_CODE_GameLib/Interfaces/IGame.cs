using System;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Interfaces
{
    public interface IGame
    {
        public event EventHandler<Game> Updated;
        public void Update();
        public bool Quit { get; }
        public bool Won { get; }
        public IPlayer Player { get; }
        public void Tick(TickData tickData);
        public void Destroy(bool winGame);
    }
}
