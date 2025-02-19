using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class MagGenerator : MonoBehaviour
{
    [SerializeField] private GameObject mag;
    [SerializeField] private XRSocketInteractor socket;

    public void GenerateMag()
    {
        GameObject go = Instantiate(mag, transform.position, transform.rotation);

        go.transform.SetParent(transform);
        socket.interactablesSelected.Add(go.GetComponent<XRGrabInteractable>());
    }
}
