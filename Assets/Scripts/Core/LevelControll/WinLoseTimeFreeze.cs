using UnityEngine;

namespace Core.LevelControll
{
    public class WinLoseTimeFreeze : MonoBehaviour
    {
        public WinLoseLinker winLoseLinker;
        
        private void OnEnable()
        {
            Time.timeScale = 1;
            winLoseLinker.winEvent.AddListener(OnGameWin);
            winLoseLinker.loseEvent.AddListener(OnGameLost);
            
        }
        private void OnDisable()
        {
            winLoseLinker.winEvent.RemoveListener(OnGameWin);
            winLoseLinker.loseEvent.RemoveListener(OnGameLost);
        }

        private void FreezeTime()
        {
            Time.timeScale = 0;
        }
        private void OnGameWin(WinArgs arg0)
        {
            FreezeTime();
        }
        private void OnGameLost(LoseArgs arg0)
        {
            FreezeTime();
        }
    }
}