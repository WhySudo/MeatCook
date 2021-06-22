using System;
using UnityEngine;

namespace Core.LevelControll
{
    public class WinUIDisplayer : UIDisplayer
    {
        public WinLoseLinker winLoseLinker;
        
        private void OnEnable()
        {
            winLoseLinker.winEvent.AddListener(OnGameWin);
        }
        private void OnDisable()
        {
            winLoseLinker.winEvent.RemoveListener(OnGameWin);
        }

        private void OnGameWin(WinArgs arg0)
        {
            DisplayPanel();
        }
    }
}