using System;
using Core.AnimatedObject;
using Core.Consuming;
using Core.Events;
using UnityEngine;

namespace Core.Tips
{
    [RequireComponent(typeof(Consumer))]
    public class SteakConsumerAnimatedObjects : MonoBehaviour
    {
        public AnimatedObjectSpawner goodSpawner;
        public AnimatedObjectSpawner badSpawner;
        
        private Consumer _consumer;
        private void Awake()
        {
            _consumer = GetComponent<Consumer>();
        }

        private void OnEnable()
        {
            _consumer.ConsumedEntityEvent.AddListener(OnEntityConsumed);
            _consumer.ConsumeEntityFallEvent.AddListener(OnEntityConsumtionFall);
        }

        private void OnDisable()
        {
            _consumer.ConsumedEntityEvent.RemoveListener(OnEntityConsumed);
            _consumer.ConsumeEntityFallEvent.RemoveListener(OnEntityConsumtionFall);
        }

        private void OnEntityConsumtionFall(ConsumeEntityFallParams arg0)
        {
            if (arg0.entity.TryGetComponent<Steak.Steak>(out var steak))
            {
                badSpawner.Spawn(arg0.entity.transform.position);
            }
        }

        private void OnEntityConsumed(ConsumedEntityParams arg0)
        {
            if (arg0.entity.TryGetComponent<Steak.Steak>(out var steak))
            {
                goodSpawner.Spawn(arg0.entity.transform.position);
            }
        }
    }
}