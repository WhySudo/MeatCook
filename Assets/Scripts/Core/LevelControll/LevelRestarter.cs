using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.LevelControll
{
    public class LevelRestarter : MonoBehaviour
    {
        public void RestartLevel()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}