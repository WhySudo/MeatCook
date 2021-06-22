using System;
using Core.Events;
using Core.Steak;
using UnityEngine;

namespace Core.WinLoseSystem
{
    [RequireComponent(typeof(SteakSide))]
    public class SteakSpoiledLose : MonoBehaviour, ILose
    {
        
        public WinLoseLinker winLoseLinker;
        private SteakSide steakSide;
        private void Awake()
        {
            steakSide = GetComponent<SteakSide>();
        }

        private void OnEnable()
        {
            steakSide.SteakSideBurntEvent.AddListener(OnSteakBurnt);
        }

        private void OnSteakBurnt(SteakSideBurntParams arg0)
        {
            Lose();
        }

        private void OnDisable()
        {
            steakSide.SteakSideBurntEvent.RemoveListener(OnSteakBurnt);
        }

        public void Lose()
        {
            winLoseLinker.Lose(new LoseArgs());
        }
    }
}