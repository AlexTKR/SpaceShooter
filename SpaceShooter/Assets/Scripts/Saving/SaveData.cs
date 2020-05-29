using System;
using System.Collections.Generic;
using Scripts.Levels;


namespace Scripts.Saving
{
    [Serializable]
    public class SaveData 
    {
        private static SaveData current;
        public static SaveData Current
        {
            get
            {
                if (current == null)
                {
                    current = new SaveData();
                    current.levelData = new List<LevelData>();
                }

                return current;
            }
            set
            {
                current = value;
            }
        }

        public List<LevelData> levelData;
    }
}