using System;
using System.Collections.Generic;
using Core.Consuming;
using UnityEngine;

namespace Core.Steak
{
    [RequireComponent(typeof(Steak))]
    public class SteakConsumability : Consumable
    {
        private Steak steak;


        public override bool CanBeConsumed(Consumer consumer)
        {
            return steak.Cooked;
        }

        protected override void OnConsumed(Consumer consumer)
        {
            Destroy(gameObject);
        }
        private void Awake()
        {
            steak = GetComponent<Steak>();
        }

    }
}