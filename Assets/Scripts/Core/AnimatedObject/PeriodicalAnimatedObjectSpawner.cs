using System.Collections;
using UnityEngine;

namespace Core.AnimatedObject
{
    
    public class PeriodicalAnimatedObjectSpawner : AnimatedObjectSpawner
    {
        public float spawnPeriod;
        
        private Coroutine _spawnerCoroutine;
        private bool _coroutineActive = false;
        
        public void StartPeriodicalSpawn(Vector3 position)
        {
            if (_coroutineActive) return;
            _coroutineActive = true;
            _spawnerCoroutine = StartCoroutine(PeriodSpawn(position));
        }

        public void StopPeriodicalSpawn()
        {
            if (!_coroutineActive) return;
            _coroutineActive = false;
            StopCoroutine(_spawnerCoroutine);
        }
        private IEnumerator PeriodSpawn(Vector3 position)
        {
            while (_coroutineActive)
            {
                Spawn(position);
                yield return new WaitForSeconds(spawnPeriod);
            }
        }
    }
}