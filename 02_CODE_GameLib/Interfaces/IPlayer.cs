using System.Collections;
using System.Collections.Generic;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib.Interfaces
{
    public interface IPlayer
    {
        public int Lives { get; set; }
        
        public IEnumerable<IKey> Keys { get; set; }
        
        public IEnumerable<ISankaraStone> SankaraStones { get; set; }
    }
}