using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockDoor : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.OnTargetHit += Unlock;
        EventManager.OnCodeEntered += Unlock;
        EventManager.OnCompleteKeySocketed += Unlock;
    }

    void OnDisable()
    {
        EventManager.OnTargetHit -= Unlock;
        EventManager.OnCodeEntered -= Unlock;
        EventManager.OnCompleteKeySocketed -= Unlock;
    }

    private void Unlock()
    {
        gameObject.SetActive(false);
    }
}
