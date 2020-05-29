using System.Collections.Generic;

namespace Scripts.Levels
{
    public class LevelHolder : LevelHolderBase
    {
        private LinkedList<LevelBase> levels;

        public override LinkedList<LevelBase> Levels
        {
            get
            {
                if (levels == null)
                {
                    levels = new LinkedList<LevelBase>();
                }

                return levels;
            }
        }
    }
}