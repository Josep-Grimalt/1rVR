using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    [SerializeField] private float speed;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * transform.forward);
    }
}
