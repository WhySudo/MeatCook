using System.Collections.Generic;
using UnityEngine;

namespace Core.Consuming
{
    public abstract class Consumable: MonoBehaviour 
    {

        public void GetConsumed(Consumer consumer)
        {
            if (CanBeConsumed(consumer))
            {
                OnConsumed(consumer);
            }
        }
        
        public abstract bool CanBeConsumed(Consumer consumer);
        protected abstract void OnConsumed(Consumer consumer);

    }
}