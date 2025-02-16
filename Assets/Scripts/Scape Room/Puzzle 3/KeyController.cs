using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class KeyController : MonoBehaviour
{
    private EventManager eventManager;
    private XRSocketInteractor socket;

    void Awake()
    {
        eventManager = GameObject.Find("Event Manager").GetComponent<EventManager>();
        socket = GetComponent<XRSocketInteractor>();
    }

    void OnEnable()
    {
        socket.selectEntered.AddListener(OnKeySelected);
    }

    private void OnKeySelected(SelectEnterEventArgs arg0)
    {
        eventManager.CompleteKeySocketed();
    }
}
