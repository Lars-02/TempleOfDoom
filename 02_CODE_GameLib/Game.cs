using CODE_GameLib.Interfaces;
using System;
using CODE_GameLib.Enums;
using CODE_GameLib.Observers;

namespace CODE_GameLib
{
    public class Game : IGame
    {
        public event EventHandler<Game> Updated;

        public bool Quit { get; private set; }

        public IPlayer Player { get; }

        public Game(IPlayer player)
        {
            Player = player;
            
            // ReSharper disable once ObjectCreationAsStatement
            new PlayerLocationObserver(this, player.Location);
            // ReSharper disable once ObjectCreationAsStatement
            new PlayerObserver(this, player);
        }

        public void Tick(TickData tickData)
        {
            if (tickData.Quit)
                Destroy();

            if (tickData.MovePlayer != null)
                Player.Move((Direction)tickData.MovePlayer);
        }

        public void Destroy()
        {
            Quit = true;
            Update();
        }

        public void Update()
        {
            Updated?.Invoke(this, this);
        }
    }
}
