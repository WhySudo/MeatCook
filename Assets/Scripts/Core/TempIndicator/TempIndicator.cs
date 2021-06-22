using System;
using System.Collections.Generic;
using Core.Steak;
using UnityEngine;

namespace Core.TempIndicator
{
    [RequireComponent(typeof(Collider))]
    public class TempIndicator : MonoBehaviour
    {
        private TempIndicatorView _indicatorView;
        private SteakSide _displayed;
        private bool _errored;
        private List<SteakSide> _sides = new List<SteakSide>();

        private void Awake()
        {
            _indicatorView = GetComponentInParent<TempIndicatorView>();
        }
        private void OnEnable()
        {
            _sides.Clear();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<SteakSide>(out var side)) return;
            _sides.Add(side);
            if (_sides.Count == 1)
            {
                _errored = false;
                _displayed = _sides[0];
            }
            else
            {
                _errored = true;
                _displayed = null;
            }

            _indicatorView.Display(_displayed, _errored);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent<SteakSide>(out var side)) return;
            _sides.Remove(side);
            if (_sides.Count == 0)
            {
                _errored = false;
                _displayed = null;
                _indicatorView.Clear();
            }
            else
            {
                _errored = _sides.Count != 1;
                _displayed = _sides[0];
                _indicatorView.Display(_displayed, _errored);
            }
        }
    }
}