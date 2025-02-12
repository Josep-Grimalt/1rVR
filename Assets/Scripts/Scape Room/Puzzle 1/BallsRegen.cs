using UnityEngine;

public class BallsRegen : MonoBehaviour
{
    private Vector3 spawnPos;

    void Awake()
    {
        spawnPos = transform.position;
    }

    void Update()
    {
        if (transform.position.y < -0.1f)
        {
            transform.position = spawnPos;
        }
    }
}
