using UnityEngine;
using System.Collections.Generic;

namespace Scripts.Spawnable
{
    public abstract class SpawnableDataBase : ScriptableObject
    {
        public abstract List<SpawnableBase> Spawnables { get; }
    }
}