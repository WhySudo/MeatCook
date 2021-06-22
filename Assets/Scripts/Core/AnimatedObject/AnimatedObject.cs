using System;
using UnityEngine;

namespace Core.AnimatedObject
{
    public class AnimatedObject : MonoBehaviour
    {
        public AnimatedObjectConfig objectConfig;
        public Vector3 finalPointOffset;

        private Vector3 _initialPoint;
        private float _movementTimer;
        private AnimatedObjectAction _animatedActor;

        public void InitObject(AnimatedObjectConfig config, Vector3 startPos, Vector3 finalPos)
        {
            objectConfig = config;
            transform.position = startPos;
            _initialPoint = startPos;
            _movementTimer = objectConfig.time;
            finalPointOffset = finalPos;
            StartMovement();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            var position = transform.position;
            Gizmos.DrawSphere(position + finalPointOffset, 0.2f);
            Gizmos.DrawLine(position, position + finalPointOffset);
        }

        private void Awake()
        {
            _animatedActor = GetComponent<AnimatedObjectAction>();
        }


        private void Update()
        {
            ProcessTimer();
        }

        private void ProcessTimer()
        {
            if (!(_movementTimer > 0)) return;
            _movementTimer = Mathf.Max(0, _movementTimer - Time.deltaTime);
            ProcessMovement();
            if (!(_movementTimer <= 0)) return;
            EndMovement();
            Destroy(gameObject, objectConfig.disappearTime);
        }

        private void StartMovement()
        {
            _animatedActor?.BeforeMovementAction();
        }

        private void ProcessMovement()
        {
            transform.position =
                _initialPoint + finalPointOffset * objectConfig.movingCurve.Evaluate(GetMovementProgress());
        }

        private void EndMovement()
        {
            _animatedActor?.BeforeDestroyAction();
        }

        private float GetMovementProgress()
        {
            return 1 - (_movementTimer / objectConfig.time);
        }
    }
}