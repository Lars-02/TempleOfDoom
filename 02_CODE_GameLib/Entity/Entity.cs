using System;
using CODE_GameLib.Enums;
using CODE_GameLib.Observers;

namespace CODE_GameLib.Entity
{
    public class Entity : BaseObservable<IEntity>, IEntity
    {
        protected Entity(int lives, ILocation location)
        {
            Location = location;
            Lives = lives;
        }

        private bool _teleported;
        private bool _pushed;

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

        public bool Teleport(ILocation teleportTo)
        {
            if (_teleported) return false;
            _teleported = true;
            Location.SetLocation(teleportTo);
            _teleported = false;
            return true;
        }
        
        public bool Push(Direction direction)
        {
            if (_pushed)
            {
                _pushed = false;
                return false;
            }
            _pushed = true;
            Move(direction);
            return true;
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
        public bool Teleport(ILocation teleportTo);
        public bool Push(Direction direction);
        public bool Move(Direction direction);
        public void ReceiveDamage(int damage);
    }
}