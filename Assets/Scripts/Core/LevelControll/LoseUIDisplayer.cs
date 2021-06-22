using UnityEngine;

namespace Core.LevelControll
{
    public class LoseUIDisplayer : UIDisplayer
    {
        public WinLoseLinker winLoseLinker;
        
        private void OnEnable()
        {
            winLoseLinker.loseEvent.AddListener(OnGameLost);
        }

        private void OnGameLost(LoseArgs arg0)
        {
            DisplayPanel();
        }

        private void OnDisable()
        {
            winLoseLinker.loseEvent.RemoveListener(OnGameLost);
        }

    }
}