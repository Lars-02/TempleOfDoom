using System;
using CODE_GameLib.Entity;
using CODE_GameLib.Enums;
using CODE_GameLib.Observers;

namespace CODE_GameLib
{
    public class Game : IGame
    {
        public Game(IPlayer player)
        {
            Player = player;

            Player.Subscribe(new EntityObserver(this));
            Player.Subscribe(new PlayerObserver(this));
            Player.Location.Subscribe(new EntityLocationObserver(this, Player));
        }

        public event EventHandler<Game> Updated;

        public bool Quit { get; private set; }
        public bool Won { get; private set; }
        public IPlayer Player { get; }

        public void Tick(TickData tickData)
        {
            if (tickData.Quit)
            {
                Destroy(false);
                return;
            }

            if (tickData.MovePlayer != null)
            {
                Player.Move((Direction) tickData.MovePlayer);
                return;
            }

            if (tickData.ToggleCheat != null)
                Player.ToggleCheat(tickData.ToggleCheat.Value);
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