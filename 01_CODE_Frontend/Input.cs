using System;
using CODE_GameLib;
using CODE_GameLib.Enums;

namespace CODE_Frontend
{
    public static class Input
    {
        public static TickData HandleKey(ConsoleKey key)
        {
            var tickData = new TickData();

            // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    tickData.MovePlayer = Direction.North;
                    break;

                case ConsoleKey.DownArrow:
                    tickData.MovePlayer = Direction.South;
                    break;

                case ConsoleKey.LeftArrow:
                    tickData.MovePlayer = Direction.West;
                    break;

                case ConsoleKey.RightArrow:
                    tickData.MovePlayer = Direction.East;
                    break;

                case ConsoleKey.S:
                    tickData.ToggleCheat = Cheat.OneMoreStone;
                    break;

                case ConsoleKey.T:
                    tickData.ToggleCheat = Cheat.DoorPortal;
                    break;

                // These cheats are disabled because these are part of assigment A an not B
                
                // case ConsoleKey.L:
                //     tickData.ToggleCheat = Cheat.Invincible;
                //     break;
                //
                // case ConsoleKey.D:
                //     tickData.ToggleCheat = Cheat.IgnoreDoors;
                //     break;

                case ConsoleKey.Spacebar:
                    tickData.Shoot = true;
                    break;

                case ConsoleKey.Escape:
                    tickData.Quit = true;
                    break;
            }

            return tickData;
        }
    }
}