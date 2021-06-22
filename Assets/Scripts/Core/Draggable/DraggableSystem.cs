using System;
using System.Collections.Generic;
using Core.InputModule;
using UnityEngine;

namespace Core.Draggable
{
    public class DraggableSystem : MonoBehaviour
    {
        public Camera gameCamera;
        public InputController inputController;

        private Dictionary<int, IDraggable> _providersAssigment = new Dictionary<int, IDraggable>();

        private void Awake()
        {
            if (gameCamera is null)
                gameCamera = Camera.main;
        }

        private void OnEnable()
        {
            _providersAssigment.Clear();
        }

        private void Update()
        {
            DraggableUpdate();
        }

        private void DraggableUpdate()
        {
            foreach (var inputId in inputController.GetAllClickProviders())
            {
                ProcessInput(inputId);
            }
        }

        private void ProcessInput(int inputId)
        {
            var uId = inputController.GetClickUniqueId(inputId);
            if (inputController.IsClickDown(inputId))
                OnClickDown(inputId, uId);
            if (inputController.IsClickMoved(inputId))
                OnClickMoved(inputId, uId);
            if (inputController.IsClickUp(inputId))
                OnClickUp(inputId, uId);
        }

        private void OnClickDown(int inputId, int uniqueId)
        {
            var drag = LocateDraggable(inputController.GetClickScreenPos(inputId));
            if (drag is null) return;
            if (_providersAssigment.ContainsValue(drag)) return;
            _providersAssigment[uniqueId] = drag;
            drag.DraggableSelected();
        }

        private void OnClickMoved(int inputId, int uniqueId)
        {
            if (!_providersAssigment.ContainsKey(inputId)) return;
            _providersAssigment[uniqueId].DraggableMoved(CalculateExpectedPoint(_providersAssigment[uniqueId],
                inputController.GetClickScreenPos(inputId)));
        }

        private void OnClickUp(int inputId, int uniqueId)
        {
            if (!_providersAssigment.ContainsKey(uniqueId)) return;
            _providersAssigment[uniqueId].DraggableReleased(CalculateExpectedPoint(_providersAssigment[uniqueId],
                inputController.GetClickScreenPos(inputId)));
            _providersAssigment.Remove(uniqueId);
        }

        private IDraggable LocateDraggable(Vector3 screenPosition)
        {
            var ray = gameCamera.ScreenPointToRay(screenPosition);
            if (!Physics.Raycast(ray, out var hit)) return null;
            return !hit.transform.TryGetComponent<IDraggable>(out var drag) ? null : drag;
        }

        private Vector3 CalculateExpectedPoint(IDraggable drag, Vector3 clickPos)
        {
            var screenPoint = gameCamera.WorldToScreenPoint(drag.GetPos()).z;
            var pos = new Vector3(clickPos.x, clickPos.y, screenPoint);
            return gameCamera.ScreenToWorldPoint(pos);
        }

        private void OnDisable()
        {
            _providersAssigment.Clear();
        }
    }
}