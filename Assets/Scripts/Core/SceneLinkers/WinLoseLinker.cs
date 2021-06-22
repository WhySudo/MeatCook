using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[Serializable]
public class LoseEvent : UnityEvent<LoseArgs>
{
};

public class LoseArgs
{
}


[Serializable]
public class WinEvent : UnityEvent<WinArgs>
{
};

public class WinArgs
{
}

[CreateAssetMenu(fileName = "winLoseConfig", menuName = "SceneLinkers/WinLoseLinker", order = 0)]
public class WinLoseLinker : ScriptableObject
{
    public LoseEvent loseEvent = new LoseEvent();
    public WinEvent winEvent = new WinEvent();

    public void Win(WinArgs args)
    {
        winEvent.Invoke(args);
    }

    public void Lose(LoseArgs args)
    {
        loseEvent.Invoke(args);
    }
}