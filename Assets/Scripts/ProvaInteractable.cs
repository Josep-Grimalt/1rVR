using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ProvaInteractable : MonoBehaviour
{
    private XRDirectInteractor interactor;

    private void Awake() {
        interactor = GetComponent<XRDirectInteractor>();

        interactor.hoverEntered.AddListener(Hovered);
        interactor.selectEntered.AddListener(Selected);
    }

    private void Selected(SelectEnterEventArgs arg0)
    {
        Debug.Log("Selected: " + arg0.interactableObject.transform.name);
    }

    private void OnDestroy() {
        interactor.hoverEntered.RemoveAllListeners();
    }

    private void Hovered(HoverEnterEventArgs arg0)
    {
        Debug.Log("Hovered: " + arg0.interactableObject.transform.name);
    }
}
