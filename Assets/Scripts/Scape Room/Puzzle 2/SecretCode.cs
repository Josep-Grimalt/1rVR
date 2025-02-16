using UnityEngine;

public class SecretCode : MonoBehaviour
{
    private Light flashlight;

    private void OnEnable()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        flashlight = other.GetComponentInChildren<Light>();
        if (flashlight && flashlight.enabled)
        {
            gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.SetActive(false);
    }
}
