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
        public bool Won { get; private set; }

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
                Destroy(false);
                return;
            }

            if (tickData.MovePlayer != null)
                Player.Move((Direction) tickData.MovePlayer);
            
            if (tickData.ToggleCheat != null && Player.Cheats.Contains(tickData.ToggleCheat.Value))
                Player.Cheats.Remove(tickData.ToggleCheat.Value);
            else if (tickData.ToggleCheat != null) Player.Cheats.Add(tickData.ToggleCheat.Value);

            Update();
        }

        public void Destroy(bool winGame)
        {
            Quit = true;
            Won = winGame;
            Update();
        }
        
       

        public void Update()
        {
            Updated?.Invoke(this, this);
        }
    }
}