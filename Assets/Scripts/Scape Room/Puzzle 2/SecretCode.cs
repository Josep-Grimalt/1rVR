using UnityEngine;

public class SecretCode : MonoBehaviour
{
    private Light flashlight;

    private void OnEnable()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        flashlight = other.GetComponentInChildren<Light>();
        if (flashlight && flashlight.enabled)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
