using UnityEngine;

namespace Core
{
    [RequireComponent(typeof(Rigidbody))]
    public class BoundRotatable : MonoBehaviour
    {
        public Bounds rotationBounds;
        public float rotationSpeed;
        private Rigidbody _rigid;

        public void SetUp(Bounds bounds)
        {
            rotationBounds = bounds;
        }
        private void Awake()
        {
            _rigid = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (rotationBounds.Contains(transform.position))
            {
                _rigid.angularVelocity = new Vector3(rotationSpeed, 0, 0);
            }
            
        }
    }
}