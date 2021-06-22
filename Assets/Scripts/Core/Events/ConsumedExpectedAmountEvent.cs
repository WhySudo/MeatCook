using System;
using Core.Consuming;
using Core.Steak;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Events
{
    public class ConsumedExpectedAmountEvent : UnityEvent<ConsumedExpectedAmountParams>
    {
    };
    public class ConsumedExpectedAmountParams
    {
    }
}