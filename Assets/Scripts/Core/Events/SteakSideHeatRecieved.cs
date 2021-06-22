using Core.Steak;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Events
{
    public class SteakSideHeatRecieved : UnityEvent<SteakSideHeatRecievedParams>
    {
    };
    public class SteakSideHeatRecievedParams
    {
        public SteakSide Side;
        public float Amount;
        public SteakSideHeatRecievedParams(SteakSide side, float amount)
        {
            Side = side;
            Amount = amount;
        }
    }
}