using System;
using System.Collections.Generic;

namespace Scripts.Levels
{
    [Serializable]
    public class LevelData 
    {
        public string levelName;
        public float levelDuration;
        public float spawnRate;
        public LevelStatus levelStatus;
        public List<string> spawnables;


        public void Init()
        {
            spawnables = new List<string>();
        }
    }
}