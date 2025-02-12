using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action OnTargetHit;

    public void TargetHit()
    {
        OnTargetHit?.Invoke();
    }
}
