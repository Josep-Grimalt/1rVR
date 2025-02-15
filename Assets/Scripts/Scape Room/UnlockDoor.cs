using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.OnTargetHit += Unlock;
        EventManager.OnCodeEntered += Unlock;
    }

    void OnDisable()
    {
        EventManager.OnTargetHit -= Unlock;
        EventManager.OnCodeEntered -= Unlock;
    }

    private void Unlock()
    {
        gameObject.SetActive(false);
    }
}
