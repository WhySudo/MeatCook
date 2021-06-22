using UnityEngine;

namespace Core
{
    public interface IDraggable
    {
        void DraggableMoved(Vector3 expectedPoint);
        void DraggableSelected();
        Vector3 GetPos();
        void DraggableReleased(Vector3 releasePoint);
    }
}