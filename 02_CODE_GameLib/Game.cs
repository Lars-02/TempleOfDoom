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

        /// <summary>
        ///     Is one game tick. So one action the player makes.
        /// </summary>
        /// <param name="tickData"> The action the player took this tick. </param>
        public void Tick(TickData tickData)
        {
            // Check if the game is quit
            if (tickData.Quit)
            {
                Destroy(false);
                return;
            }

            // Check if the player moves
            if (tickData.MovePlayer != null)
            {
                // Move player
                if (!Player.Move((Direction) tickData.MovePlayer)) return;

                // Move enemies
                foreach (var enemy in Enemies.Where(enemy =>
                    !enemy.Died && enemy.Location.Room == Player.Location.Room))
                    enemy.Move();

                // Check if player is on an enemy
                if (Player.Location.IsEnemy(Enemies))
                    Player.ReceiveDamage(1);
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


        private void Update()
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
        public void Tick(TickData tickData);
        public void Destroy(bool winGame);
    }
}