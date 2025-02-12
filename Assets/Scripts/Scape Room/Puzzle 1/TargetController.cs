using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class TargetController : MonoBehaviour
{
    private XRSocketInteractor socket;
    private EventManager eventManager;

    void Awake()
    {
        eventManager = GameObject.Find("Event Manager").GetComponent<EventManager>();
        socket = GetComponent<XRSocketInteractor>();
    }

    void OnEnable()
    {
        socket.selectEntered.AddListener(TargetHit);
    }

    private void TargetHit(SelectEnterEventArgs arg0)
    {
        eventManager.TargetHit();
    }
}
