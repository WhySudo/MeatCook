using System;
using Core.Steak;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Events
{
    [Serializable]
    public class HeatEmissionBeganEvent : UnityEvent<HeatEmissionBeganParams>
    {
    };

    public class HeatEmissionBeganParams
    {
        public SteakSide SteakSide;
        public HeatEmiter HeatEmiter;

        public HeatEmissionBeganParams(SteakSide steakSide, HeatEmiter heatEmiter)
        {
            SteakSide = steakSide;
            HeatEmiter = heatEmiter;
        }
    }
}