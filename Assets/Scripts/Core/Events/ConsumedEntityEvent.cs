using Core.Consuming;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Events
{
    public class ConsumedEntityEvent : UnityEvent<ConsumedEntityParams>
    {
    };
    public class ConsumedEntityParams
    {
        public Consumable entity;

        public ConsumedEntityParams(Consumable entity)
        {
            this.entity = entity;
        }
    }
}