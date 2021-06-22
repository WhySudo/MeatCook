using System;
using Core.Steak;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Events
{
    [Serializable]

    public class HeatEmissionEndedEvent : UnityEvent<HeatEmissionEndedParams>
    {
    };

    public class HeatEmissionEndedParams
    {
        public SteakSide SteakSide;
        public HeatEmiter HeatEmiter;

        public HeatEmissionEndedParams(SteakSide steakSide, HeatEmiter heatEmiter)
        {
            SteakSide = steakSide;
            HeatEmiter = heatEmiter;
        }
    }
}