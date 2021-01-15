using System;
using System.Linq;
using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Observers;

namespace CODE_GameLib.Entity
{
    public class Entity : BaseObservable<IEntity>, IEntity
    {
        public ILocation Location { get; }
        
        public int Lives { get; private set; }

        public bool Died => Lives < 1;

        protected Entity(int lives, ILocation location)
        {
            Location = location;
            Lives = lives;
        }

        public bool Move(Direction direction)
        {
            var (x, y) = DirectionToPosition(direction);
            
            var destination = Location.Room.GetDestination(x, y, direction, this);
            
            return destination != null && Location.SetLocation(destination);
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

        public bool ReceiveDamage(int damage)
        {
            if (damage <= 0)
                return false;
            Lives -= damage;
            NotifyObservers(this);
            return true;
        }
    }
}