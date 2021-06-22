using UnityEngine;

namespace Core.Consuming
{
    public class ConsumableDestroy : Consumable
    {
        public override bool CanBeConsumed(Consumer consumer)
        {
            return true;
        }

        protected override void OnConsumed(Consumer consumer)
        {
            Destroy(gameObject);
        }
    }
}