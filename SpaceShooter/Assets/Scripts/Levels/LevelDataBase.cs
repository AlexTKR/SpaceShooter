using System;
using System.Collections.Generic;

namespace Scripts.Levels
{
    [Serializable]
    public abstract class LevelDataBase 
    {
        public abstract string LevelName { get; set; }
        public abstract float LevelDuration { get; set; }
        public abstract List<string> Spawnables { get; set; }
    }
}