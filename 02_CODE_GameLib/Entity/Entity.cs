using System;
using CODE_GameLib.Enums;
using CODE_GameLib.Observers;

namespace CODE_GameLib.Entity
{
    public class Entity : BaseObservable<IEntity>, IEntity
    {
        private bool _pushed;

        private bool _teleported;

        protected Entity(int lives, ILocation location)
        {
            Location = location;
            Lives = lives;
        }

        protected Entity()
        {
        }

        public virtual ILocation Location { get; }
        public virtual int Lives { get; private set; }
        public bool Died => Lives < 1;

        public bool Move(Direction direction)
        {
            var (x, y) = DirectionToPosition(direction);

            var destination = Location.Room.GetDestination(x, y, direction, this);

            return destination != null && Location.SetLocation(destination);
        }

        public void Teleport(ILocation teleportTo)
        {
            if (_teleported) return;
            _teleported = true;
            Location.SetLocation(teleportTo);
            _teleported = false;
        }

        public void Push(Direction direction)
        {
            if (_pushed)
            {
                _pushed = false;
                return;
            }

            _pushed = true;
            Move(direction);
            _pushed = false;
        }

        public virtual void ReceiveDamage(int damage)
        {
            if (damage <= 0)
                return;
            Lives -= damage;
            NotifyObservers(this);
        }

        private (int, int) DirectionToPosition(Direction direction)
        {
            var targetX = Location.X;
            var targetY = Location.Y;

            switch (direction)
            {
                case Direction.North:
                    targetY--;
                    break;
                case Direction.East:
                    targetX++;
                    break;
                case Direction.South:
                    targetY++;
                    break;
                case Direction.West:
                    targetX--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction,
                        "There are only four directions");
            }

            return (targetX, targetY);
        }
    }

    public interface IEntity : IBaseObservable<IEntity>
    {
        public ILocation Location { get; }
        public int Lives { get; }
        public bool Died { get; }
        public void Teleport(ILocation teleportTo);
        public void Push(Direction direction);
        public bool Move(Direction direction);
        public void ReceiveDamage(int damage);
    }
}