using System;
using System.Linq;
using Core.Draggable;
using UnityEngine;

namespace Core.Steak
{
    [RequireComponent(typeof(DraggableMovement))]
    [RequireComponent(typeof(BoundRotatable))]
    public class Steak : MonoBehaviour
    {
        public SteakSide[] steakSides;
        public bool Cooked => steakSides.Aggregate(true, (current, side) => current && side.Ready);
        public bool Burnt => steakSides.Aggregate(false, (current, side) => current || side.Burnt);
        
        private DraggableMovement _movement;
        private BoundRotatable _rotation;
        public void SetUp(Bounds movingBounds, Bounds rotationBounds)
        {
            _movement.SetUp(movingBounds);
            _rotation.SetUp(rotationBounds);
        }

        private void Awake()
        {
            _movement = GetComponent<DraggableMovement>();
            _rotation = GetComponent<BoundRotatable>();
        }
        
    }
}