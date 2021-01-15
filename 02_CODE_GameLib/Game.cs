using CODE_GameLib.Interfaces;
using System;
using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces.Entity;
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

            Player.Subscribe(new PlayerObserver(this));
            // ReSharper disable once ObjectCreationAsStatement
            new PlayerLocationObserver(this, player.Location);
        }

        public void Tick(TickData tickData)
        {
            if (tickData.Quit)
            {
                Destroy();
                return;
            }

            if (tickData.MovePlayer != null)
                Player.Move((Direction) tickData.MovePlayer);
            
            if (Player.Cheats.Contains(tickData.ToggleCheat))
                Player.Cheats.Remove(tickData.ToggleCheat);
            else
                Player.Cheats.Add(tickData.ToggleCheat);

            Update();
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