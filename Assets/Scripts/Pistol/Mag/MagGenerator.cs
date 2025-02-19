using UnityEngine;

public class MagGenerator : MonoBehaviour
{
    [SerializeField] private GameObject mag;

    public void GenerateMag()
    {
        GameObject go = Instantiate(mag, transform.position, transform.rotation);

        go.transform.SetParent(transform);
    }
}
