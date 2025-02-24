using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class MagGenerator : MonoBehaviour
{
    [SerializeField] private GameObject mag;
    [SerializeField] private XRSocketInteractor socket;
    [SerializeField] private float delay;

    private bool magGenerated;

    void Awake()
    {
        magGenerated = false;
    }

    public void GenerateMag()
    {
        if (magGenerated) return;

        StartCoroutine(SpawnMag());
    }

    private IEnumerator SpawnMag()
    {
        while (socket.hasSelection) yield return null;

        magGenerated = true;

        GameObject go = Instantiate(mag, transform.position, transform.rotation);

        socket.StartManualInteraction(go.GetComponent<IXRSelectInteractable>());

        yield return new WaitForSeconds(delay);

        magGenerated = false;
    }
}
