using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private int magCapacity;
    [SerializeField] private XRSocketInteractor socket;

    private int mag;


    void Awake()
    {
        mag = magCapacity;
    }

    public void Shot()
    {
        if (mag > 0)
        {
            Debug.Log("Shooting");
            mag--;
            GameObject go = Instantiate(bullet, transform.position, transform.rotation);

            Destroy(go, 2f);
        }
    }

    public void Reload()
    {
        if (mag == 0)
        {
            mag = magCapacity;
        }
        else
        {
            mag = magCapacity + 1;
        }
    }
}
