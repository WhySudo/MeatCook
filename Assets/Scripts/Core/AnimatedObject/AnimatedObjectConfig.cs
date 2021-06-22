using UnityEngine;

namespace Core.AnimatedObject
{
    [CreateAssetMenu(fileName = "animatedObjectConfig", menuName = "AnimatedObject/Config", order = 2)]
    public class AnimatedObjectConfig : ScriptableObject
    {
        public AnimationCurve movingCurve;
        public float time;
        public float disappearTime;
        public Vector3 offsetSpawnPoint;
    }
}