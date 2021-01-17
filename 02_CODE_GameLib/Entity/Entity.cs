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

        protected Entity(int lives, ILocation location, ILocation movedFromLast)
        {
            Lives = lives;
            Location = location;
        }

        private bool Teleported { get; set; }
        public ILocation Location { get; }
        public int Lives { get; private set; }
        public bool Died => Lives < 1;

        public bool Move(Direction direction)
        {
            var (x, y) = DirectionToPosition(direction);

            var destination = Location.Room.GetDestination(x, y, direction, this);

            if (destination == null || !Location.SetLocation(destination)) return false;

            Teleported = false;
            return true;
        }

        public bool Teleport(ILocation teleportTo)
        {
            if (Teleported) return false;
            Teleported = true;
            return Location.SetLocation(teleportTo);
        }

        public bool ReceiveDamage(int damage)
        {
            if (damage <= 0)
                return false;
            Lives -= damage;
            NotifyObservers(this);
            return true;
        }

        private (int, int) DirectionToPosition(Direction direction)
        {
            var targetX = Location.X;
            var targetY = Location.Y;

            switch (direction)
            {
                case Direction.North:
                    targetY++;
                    break;
                case Direction.East:
                    targetX++;
                    break;
                case Direction.South:
                    targetY--;
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
        public bool Move(Direction direction);
        public bool ReceiveDamage(int damage);
    }
}