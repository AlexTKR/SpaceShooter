using System.Collections.Generic;

namespace Scripts.Levels
{
    public abstract class LevelHolderBase 
    {
        public abstract LinkedList<LevelBase> Levels { get; } 
    }
}