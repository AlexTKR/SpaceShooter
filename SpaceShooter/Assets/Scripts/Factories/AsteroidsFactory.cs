using UnityEngine;
using System.Collections.Generic;
using Scripts.Spawnable;

namespace Scripts.Factories
{
    public class AsteroidsFactory : AsteroidsFactoryBase
    {
        [SerializeField] private SpawnableDataBase asteroidsData;

        private Dictionary<string, SpawnableBase> asterods;

        public override SpawnableBase GetItem(string name)
        {
            if (asterods == null)
            {
                InitFactory();
            }

            if (asterods.ContainsKey(name))
            {
                SpawnableBase asteroid = Instantiate(asterods[name]);
                asteroid.gameObject.SetActive(false);
                return asteroid;
            }
            else
            {
                return null;
            }

        }

        private void InitFactory()
        {
            asterods = new Dictionary<string, SpawnableBase>();

            for (int i = 0; i < asteroidsData.Spawnables.Count; i++)
            {
                asterods.Add(asteroidsData.Spawnables[i].name, asteroidsData.Spawnables[i]);
            }
        }
    }
}