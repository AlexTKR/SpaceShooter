using System;
using System.Collections.Generic;

namespace Scripts.Levels
{
    [Serializable]
    public class LevelData : LevelDataBase
    {
        private string levelName;
        private float levelDuration;
        private List<string> spawnables;

        public override string LevelName { get => levelName; set => levelName = value; }
        public override float LevelDuration { get => levelDuration; set => levelDuration = value; }
        public override List<string> Spawnables
        {
            get
            {
                if (spawnables == null)
                {
                    spawnables = new List<string>();
                }
                return spawnables;
            }
            set => spawnables = value;
        }
    }
}