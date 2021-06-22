using System;
using Core.AnimatedObject;
using Core.Events;
using Core.Steak;
using UnityEngine;

namespace Core.Tips
{
    [RequireComponent(typeof(AnimatedObjectSpawner))]
    [RequireComponent(typeof(SteakSide))]
    public class SteakSideAnimatedObjects : MonoBehaviour
    {
        public AnimatedObjectSpawner goodSpawner;
        public AnimatedObjectSpawner tooMuchSpawner;

        private SteakSide _side;

        private void Awake()
        {
            _side = GetComponent<SteakSide>();
        }

        private void OnEnable()
        {
            _side.SteakSideCookedEvent.AddListener(OnSteakSideCooked);
            _side.SideBeganRecievingHeatEvent.AddListener(OnSteakHeatRecieved);
        }

        private void OnSteakHeatRecieved(SteakSideBeganRecievingHeatParams arg0)
        {
            if(_side.Ready)
                tooMuchSpawner.Spawn(_side.transform.position);
        }
        

        private void OnSteakSideCooked(SteakSideCookedParams arg0)
        {
            goodSpawner.Spawn(_side.transform.position);
        }

        private void OnDisable()
        {
            _side.SteakSideCookedEvent.RemoveListener(OnSteakSideCooked);
            _side.SideBeganRecievingHeatEvent.RemoveListener(OnSteakHeatRecieved);
        }
    }
}