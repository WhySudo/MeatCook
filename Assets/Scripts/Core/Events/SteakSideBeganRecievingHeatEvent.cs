using Core.Steak;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Events
{
    public class SteakSideBeganRecievingHeatEvent : UnityEvent<SteakSideBeganRecievingHeatParams>
    {
    };
    public class SteakSideBeganRecievingHeatParams
    {
        public SteakSide side;

        public SteakSideBeganRecievingHeatParams(SteakSide side)
        {
            this.side = side;
        }
    }
}