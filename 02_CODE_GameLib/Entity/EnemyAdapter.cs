using System;
using CODE_TempleOfDoom_DownloadableContent;

namespace CODE_GameLib.Entity
{
    public class EnemyAdapter : Entity, IEnemy
    {
        private readonly Enemy _adaptee;
        private readonly EnemyLocationAdapter _location;

        public EnemyAdapter(Enemy enemy, EnemyLocationAdapter location)
        {
            _adaptee = enemy;
            _location = location;
        }

        public override int Lives => _adaptee.NumberOfLives;
        public override ILocation Location => _location;

        public override void ReceiveDamage(int damage) => _adaptee.GetHurt(damage);

        /// <summary>
        /// Moves the enemy following it's route
        /// </summary>
        public void Move()
        {
            _adaptee.Move();
        }
    }

    public interface IEnemy : IEntity
    {
        public void Move();
    }
}