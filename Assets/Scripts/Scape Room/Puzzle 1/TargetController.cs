using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class TargetController : MonoBehaviour
{
    private EventManager eventManager;
    private XRSocketInteractor socket;

    private void Awake()
    {
        eventManager = GameObject.Find("Event Manager").GetComponent<EventManager>();
        socket = GetComponent<XRSocketInteractor>();
    }

    private void OnEnable()
    {
        socket.selectEntered.AddListener(TargetHit);
    }

    private void TargetHit(SelectEnterEventArgs arg0)
    {
        eventManager.TargetHit();
    }

}
