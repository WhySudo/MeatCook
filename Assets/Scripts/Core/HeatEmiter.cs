using System;
using Core.Events;
using Core.Steak;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    [RequireComponent(typeof(Collider))]
    public class HeatEmiter : MonoBehaviour
    {
        public float tempEmission;
        public HeatEmissionBeganEvent heatEmissionBeganEvent = new HeatEmissionBeganEvent();
        public HeatEmissionEndedEvent heatEmissionEndedEvent = new HeatEmissionEndedEvent();

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<SteakSide>(out var steakSide)) return;
            steakSide.BeginGainHeat(this);
            heatEmissionBeganEvent.Invoke(new HeatEmissionBeganParams(steakSide, this));
        }

        private void OnTriggerStay(Collider other)
        {
            if (!other.TryGetComponent<SteakSide>(out var steakSide)) return;
            steakSide.GainHeat(tempEmission* Time.deltaTime, this);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent<SteakSide>(out var steakSide)) return;
            steakSide.EndGainHeat(this);
            heatEmissionEndedEvent.Invoke(new HeatEmissionEndedParams(steakSide, this));
        }
    }
}