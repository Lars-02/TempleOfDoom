using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;
using System.Collections.Generic;

namespace CODE_GameLib
{
    public class Room : IRoom
    {
        public int Width { get; }
        public int Height { get; }
        public int CenterX => (Width + 1) / 2 - 1;
        public int CenterY => (Height + 1) / 2 - 1;
        public List<IItem> Items { get; }
        public IEnumerable<IConnection> Connections { get; }

        public Room(int width, int height, List<IItem> items, IEnumerable<IConnection> connections)
        {
            Width = width;
            Height = height;
            Items = items;
            Connections = connections;
        }
    }
}
