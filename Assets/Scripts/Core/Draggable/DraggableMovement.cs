using Core.Steak;
using UnityEngine;

namespace Core.Draggable
{
    [RequireComponent(typeof(Rigidbody))]
    public class DraggableMovement : MonoBehaviour, IDraggable
    {
        
        public bool IsMoving => _isMoving;
        
        public Bounds movingBounds;
        
        private float _fixedAxis;
        private bool _isMoving;
        private Rigidbody _rigid;

        public void SetUp(Bounds bounds)
        {
            movingBounds = bounds;
        }
        public void DraggableMoved(Vector3 expectedPoint)
        {
            Debug.DrawLine(expectedPoint, transform.position);
            MoveDraggable(expectedPoint);
        }
        public void DraggableSelected()
        {
            _isMoving = true;
            _rigid.useGravity = false;
        }

        public Vector3 GetPos()
        {
            return transform.position;
        }

        public void DraggableReleased(Vector3 releasePoint)
        {
            _isMoving = false;
            _rigid.velocity = releasePoint - transform.position;
            _rigid.useGravity = true;
        }
        private void Awake()
        {
            _rigid = GetComponent<Rigidbody>();
        }

        
        private void OnEnable()
        {
            _fixedAxis = transform.position.z;
        }

        
        private void MoveDraggable(Vector3 expectedPoint)
        {
            Vector3 pos; // = expectedPoint;
            if (!movingBounds.Contains(expectedPoint))
            {
                var closestPoint = movingBounds.ClosestPoint(expectedPoint);
                pos = new Vector3(closestPoint.x, closestPoint.y, _fixedAxis);
            }
            else
            {
                pos = new Vector3(expectedPoint.x, expectedPoint.y, _fixedAxis);
            }

            _rigid.velocity = Vector3.zero;
            _rigid.MovePosition(pos);
            //rigid.position = pos;
        }

       
    }
}