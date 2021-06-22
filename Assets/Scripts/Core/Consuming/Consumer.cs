using System;
using Core.Events;
using UnityEngine;

namespace Core.Consuming
{
    [RequireComponent(typeof(Collider))]
    public class Consumer : MonoBehaviour
    {
        public readonly ConsumeEntityFallEvent ConsumeEntityFallEvent = new ConsumeEntityFallEvent();
        public readonly ConsumedEntityEvent ConsumedEntityEvent = new ConsumedEntityEvent();

        //public readonly ConsumedExpectedAmountEvent ConsumedExpectedAmountEvent = new ConsumedExpectedAmountEvent();
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<Consumable>(out var entity)) return;
            TryConsumeEntity(entity);
        }

        private void TryConsumeEntity(Consumable entity)
        {
            if (!entity.CanBeConsumed(this))
            {
                ConsumeEntityFallEvent.Invoke(new ConsumeEntityFallParams(entity));
                return;
            }

            entity.GetConsumed(this);
            ConsumedEntityEvent.Invoke(new ConsumedEntityParams(entity));
        }
    }
}