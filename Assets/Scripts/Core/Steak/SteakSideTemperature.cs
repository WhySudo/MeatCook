using UnityEngine;

namespace Core.Steak
{
    [CreateAssetMenu(fileName = "SteakTempConfig", menuName = "Scriptable/SteakSideTemperature", order = 0)]
    public class SteakSideTemperature : ScriptableObject
    {
        public float minimal;
        public float ready;
        public float maximum;
        private void OnValidate()
        {
            ready = Mathf.Clamp(ready, minimal, maximum);
            if (minimal > ready)
            {
                ready = minimal;
            }

            if (ready > maximum)
            {
                maximum = ready;
            }
        }
    }
}