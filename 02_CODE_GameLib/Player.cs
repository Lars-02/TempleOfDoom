using System;
using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items.Wearable;

namespace CODE_GameLib
{
    public class Player : IPlayer
    {
        public IPlayerLocation Location { get; }
        public int Lives { get; set; }

        public List<IWearable> Inventory { get; set; }

        public Player(int lives, List<IWearable> inventory,
            IPlayerLocation location)
        {
            Lives = lives;
            Inventory = inventory;
            Location = location;
        }

        public bool Move(Direction direction)
        {
            var targetX = Location.X;
            var targetY = Location.Y;
            var targetRoom = Location.Room;

            switch (direction)
            {
                case Direction.Top:
                    targetY++;
                    break;
                case Direction.Right:
                    targetX++;
                    break;
                case Direction.Bottom:
                    targetY--;
                    break;
                case Direction.Left:
                    targetX--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction,
                        "There are only four directions");
            }

            if (targetX < 0 || targetY < 0 || targetX > targetRoom.Width - 1 || targetY > targetRoom.Height - 1)
            {
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

                if (destination.Direction == Direction.Top || destination.Direction == Direction.Bottom)
                {
                    targetX = (targetRoom.Width + 1) / 2 - 1;
                    targetY = destination.Direction == Direction.Top ? targetRoom.Height - 1 : 0;
                }
                else
                {
                    targetX = destination.Direction == Direction.Left ? 0 : targetRoom.Width - 1;
                    targetY = (targetRoom.Height + 1) / 2 - 1;
                }
            }

            Location.Update(targetRoom, targetX, targetY);
            return true;
        }
    }
}
