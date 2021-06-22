using UnityEngine;

namespace Core.AnimatedObject
{
    public class AnimatedObjectSpawner : MonoBehaviour
    {
        public AnimatedObject prefab;
        public AnimatedObjectConfig config;
        public void Spawn(Vector3 position)
        {
            var aObject = Instantiate(prefab);
            aObject.InitObject( config,position, config.offsetSpawnPoint);
        }
    }
}