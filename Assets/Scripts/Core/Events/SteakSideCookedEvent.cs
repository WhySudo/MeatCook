using Core.Steak;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Events
{
    public class SteakSideCookedEvent : UnityEvent<SteakSideCookedParams>
    {
    };
    public class SteakSideCookedParams
    {
        public SteakSide side;

        public SteakSideCookedParams(SteakSide side)
        {
            this.side = side;
        }
    }

}