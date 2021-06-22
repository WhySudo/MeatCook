using UnityEngine;

namespace Core.LevelControll
{
    public abstract class UIDisplayer : MonoBehaviour
    {
        public GameObject displayingPanel;
        public void DisplayPanel()
        {
            displayingPanel.SetActive(true);
        }
        public void HidePanel()
        {
            displayingPanel.SetActive(false);
        }
    }
}