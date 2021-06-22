using System;
using System.Collections;
using System.Collections.Generic;
using Core.Steak;
using UnityEngine;
using UnityEngine.UI;

namespace Core.TempIndicator
{
    public class TempIndicatorView : MonoBehaviour
    {
        public Text displayingText;


        public void Display(SteakSide side, bool error = false)
        {
            if (error)
            {
                displayingText.text = "ERROR";
            }
            else if (side.Ready)
            {
                displayingText.text = "OK";
            }
            else if (side.Burnt)
            {
                displayingText.text = "BAD";
            }
            else
            {
                displayingText.text = "RAW";
            }
        }

        public void Clear()
        {
            displayingText.text = "";
        }

        private void OnEnable()
        {
            Clear();
        }
    }
}