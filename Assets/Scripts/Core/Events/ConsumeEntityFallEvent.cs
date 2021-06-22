using Core.Consuming;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Events
{

    public class ConsumeEntityFallEvent : UnityEvent<ConsumeEntityFallParams>
    {
    };

    public class ConsumeEntityFallParams
    {
        public Consumable entity;

        public ConsumeEntityFallParams(Consumable entity)
        {
            this.entity = entity;
        }
    }
}