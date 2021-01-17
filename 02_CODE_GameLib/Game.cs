using System;
using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Entity;
using CODE_GameLib.Enums;
using CODE_GameLib.Observers;

namespace CODE_GameLib
{
    public class Game : IGame
    {
        public Game(IPlayer player, List<IEnemy> enemies)
        {
            Player = player;
            Enemies = enemies;

            Player.Subscribe(new EntityObserver(this));
            Player.Location.Subscribe(new EntityLocationObserver(this, Player));

            foreach (var enemy in Enemies)
            {
                enemy.Subscribe(new EntityObserver(this));
                enemy.Location.Subscribe(new EntityLocationObserver(this, enemy));
            }
        }

        public event EventHandler<Game> Updated;

        public bool Quit { get; private set; }
        public bool Won { get; private set; }
        public IPlayer Player { get; }
        public List<IEnemy> Enemies { get; }

        public void Tick(TickData tickData)
        {
            if (tickData.Quit)
            {
                Destroy(false);
                return;
            }

            if (tickData.MovePlayer != null)
            {
                if (!Player.Move((Direction) tickData.MovePlayer)) return;
                foreach (var enemy in Enemies.Where(enemy =>
                    !enemy.Died && enemy.Location.Room == Player.Location.Room))
                    enemy.Move();
            }

            if (tickData.Shoot)
                Player.Shoot(Enemies.Where(enemy =>
                    !enemy.Died && enemy.Location.WithinShootingRange(Player.Location)));

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
        public List<IEnemy> Enemies { get; }
        public event EventHandler<Game> Updated;
        public void Update();
        public void Tick(TickData tickData);
        public void Destroy(bool winGame);
    }
}