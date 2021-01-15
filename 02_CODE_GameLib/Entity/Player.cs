using System;
using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items.Wearable;

namespace CODE_GameLib.Entity
{
    public class Player : Entity, IPlayer
    {
        private readonly List<IWearable> _inventory;
        public IEntityLocation Location { get; }
        public int Lives { get; private set; }

        public bool Died => Lives < 1;

        public bool Won => Inventory.Count(wearable => wearable is ISankaraStone) >= 5;

        public IEnumerable<IWearable> Inventory => _inventory;

        public Player(int lives, List<IWearable> inventory,
            IEntityLocation location)
        {
            Lives = lives;
            _inventory = inventory;
            Location = location;
        }

        public bool ReceiveDamage(int damage)
        {
            if (damage <= 0)
                return false;
            Lives -= damage;
            NotifyObservers(this);
            return true;
        }

        public bool AddToInventory(IWearable wearable)
        {
            _inventory.Add(wearable);
            NotifyObservers(this);
            return true;
        }

        public bool Move(Direction direction)
        {
            var targetX = Location.X;
            var targetY = Location.Y;
            var targetRoom = Location.Room;

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

            if (targetX >= 1 && targetY >= 1 && targetX <= targetRoom.Width - 2 && targetY <= targetRoom.Height - 2)
                return Location.Update(targetRoom, targetX, targetY);
            
            var isCenterX = targetX == (targetRoom.Width + 1) / 2 - 1;
            var isCenterY = targetY == (targetRoom.Height + 1) / 2 - 1;

            if (!isCenterX && !isCenterY)
                return false;

            var connection = targetRoom.Connections.FirstOrDefault(
                connections => connections.Direction == direction);

            if (connection == null) return false;

            if (connection.Door != null && !connection.Door.PassThru(this))
                return false;

            var destination = connection.Destination;
            targetRoom = destination.Room;

            if (destination.Direction == Direction.North || destination.Direction == Direction.South)
            {
                targetX = (targetRoom.Width + 1) / 2 - 1;
                targetY = destination.Direction == Direction.South ? 0 : targetRoom.Height - 1;
            }
            else
            {
                targetX = destination.Direction == Direction.West ? 0 : targetRoom.Width - 1;
                targetY = (targetRoom.Height + 1) / 2 - 1;
            }

            return Location.Update(targetRoom, targetX, targetY);
        }
    }
}
