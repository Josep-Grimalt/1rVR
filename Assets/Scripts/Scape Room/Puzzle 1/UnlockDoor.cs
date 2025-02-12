using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.OnTargetHit += Unlock;
    }

    void OnDisable()
    {
        EventManager.OnTargetHit -= Unlock;
    }

    private void Unlock()
    {
        gameObject.SetActive(false);
    }
}
