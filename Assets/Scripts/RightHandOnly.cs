using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class RightHandOnly : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private bool isRightHandHeld = false;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnEntered);
        grabInteractable.selectExited.AddListener(OnExited);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnEntered);
        grabInteractable.selectExited.RemoveListener(OnExited);
    }

    private void OnExited(SelectExitEventArgs arg0)
    {
        isRightHandHeld = false;
    }

    private void OnEntered(SelectEnterEventArgs arg0)
    {
        var interactor = arg0.interactorObject.transform;

        if(interactor.CompareTag("RightHand"))
        {
            isRightHandHeld = true;
        }
        else
        {
            isRightHandHeld = false;
        }
    }

    public bool IsRightHandHeld()
    {
        return isRightHandHeld;
    }
}
