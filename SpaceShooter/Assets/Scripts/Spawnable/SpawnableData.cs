using UnityEngine;
using System.Collections.Generic;

namespace Scripts.Spawnable
{
    [CreateAssetMenu(menuName ="SpawnableData", fileName ="SpawnableData")]
    public class SpawnableData : SpawnableDataBase
    {
        [SerializeField] private List<SpawnableBase> spawnables;

        public override List<SpawnableBase> Spawnables => spawnables;
    }
}