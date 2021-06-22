using UnityEngine;

namespace Core.AnimatedObject
{
    public abstract class AnimatedObjectAction : MonoBehaviour
    {
        public void BeforeDestroyAction()
        {
            BeforeDestroy();
        }
        public void BeforeMovementAction()
        {
            OnMovementBegin();
        }

        protected abstract void BeforeDestroy();
        protected abstract void OnMovementBegin();
    }
}