using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action OnTargetHit;
    public static event Action OnCodeEntered;

    public void TargetHit()
    {
        OnTargetHit?.Invoke();
    }

    public void CodeEntered()
    {
        OnCodeEntered?.Invoke();
    }
}
