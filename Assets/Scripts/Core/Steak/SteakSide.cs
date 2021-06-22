using System;
using Core.Events;
using UnityEngine;

namespace Core.Steak
{
    [RequireComponent(typeof(Collider))]
    public class SteakSide : MonoBehaviour
    {
        public bool Ready => _status >= temperature.ready && _status < temperature.maximum;
        public bool Burnt => _status >= temperature.maximum;
        
        public SteakSideCookedEvent SteakSideCookedEvent = new SteakSideCookedEvent();
        public SteakSideBurntEvent SteakSideBurntEvent = new SteakSideBurntEvent();
        public SteakSideHeatRecieved SteakSideHeatRecieved = new SteakSideHeatRecieved();
        public SteakSideBeganRecievingHeatEvent SideBeganRecievingHeatEvent = new SteakSideBeganRecievingHeatEvent();
        
        public SteakSideTemperature temperature;
        
        private bool _burntInvoked = false;
        private bool _readyInvoked = false;
        private float _status;

        public void BeginGainHeat(HeatEmiter source)
        {
            SideBeganRecievingHeatEvent.Invoke(new SteakSideBeganRecievingHeatParams(this));   
        }
        public void EndGainHeat(HeatEmiter source)
        {
            
        }


        public void GainHeat(float value, HeatEmiter source)
        {
            _status += value;
            SteakSideHeatRecieved.Invoke(new SteakSideHeatRecievedParams(this, value));
            if (Ready && !_readyInvoked)
            {
                _readyInvoked = true;
                SteakSideCookedEvent.Invoke(new SteakSideCookedParams(this));
            }
            if (Burnt && !_burntInvoked)
            {
                _burntInvoked = true;
                SteakSideBurntEvent.Invoke(new SteakSideBurntParams(this));
            }
        }
        private void Start()
        {
            _status = temperature.minimal;
            _burntInvoked = false;
            _readyInvoked = false;
        }

        
    }
}