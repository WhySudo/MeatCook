using Core.Steak;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Events
{
    public class SteakSideBurntEvent : UnityEvent<SteakSideBurntParams>
    {
    };
    public class SteakSideBurntParams
    {
        public SteakSide side;

        public SteakSideBurntParams(SteakSide side)
        {
            this.side = side;
        }
    }
}