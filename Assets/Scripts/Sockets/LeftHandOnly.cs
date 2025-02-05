using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class LeftHandOnly : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private bool isLeftHandHeld = false;

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
        isLeftHandHeld = false;
    }

    private void OnEntered(SelectEnterEventArgs arg0)
    {
        var interactor = arg0.interactorObject.transform;

        if(interactor.CompareTag("LeftHand"))
        {
            isLeftHandHeld = true;
        }
        else
        {
            isLeftHandHeld = false;
        }
    }

    public bool IsLeftHandHeld()
    {
        return isLeftHandHeld;
    }
}
