using System;
using Core.Consuming;
using Core.Events;
using UnityEngine;

namespace Core.WinLoseSystem
{
    [RequireComponent(typeof(Consumer))]
    public class SteaksConsumedWin : MonoBehaviour, IWin
    {
        public WinLoseLinker winLoseLinker;
        public int countToWin;
        public int startCount;
        private int count;
        private Consumer entity;
        private void Awake()
        {
            entity = GetComponent<Consumer>();
            count = startCount;
        }

        private void OnEnable()
        {
            entity.ConsumedEntityEvent.AddListener(EntityConsumed);
        }

        private void OnDisable()
        {
            entity.ConsumedEntityEvent.RemoveListener(EntityConsumed);         
        }

        private void EntityConsumed(ConsumedEntityParams args)
        {
            if (!args.entity.TryGetComponent<Steak.Steak>(out var steak)) return;
            if(steak.Cooked)IncreaseCount();
        }

        private void IncreaseCount()
        {
            count++;
            if (count == countToWin) Win();
        }
        public void Win()
        {
            winLoseLinker.Win(new WinArgs());
        }
    }
}