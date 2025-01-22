using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

/*
Aquesta classe gestiona grab
Quan agafes l'objecte la mà que l'agafa canvia de color
Quan agafes l'objecte, aquest canvia a un color X.
Quan actives l'objecte, aquest canvia a un color Y.
Quan desactives l'objecte, aquest torna al color X.
Quan deixes anar l'objecte, tot torna al seu color original.
*/

public class DirectInteractable : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable[] grabInteractables;
    [SerializeField] private List<Material> materials = new List<Material>();

    private void Awake()
    {
        foreach (XRGrabInteractable interactable in grabInteractables)
        {
            interactable.selectEntered.AddListener(Selected);
            interactable.selectExited.AddListener(Exit);
            interactable.activated.AddListener(Activated);
        }

    }

    private void OnDestroy()
    {
        foreach (XRGrabInteractable interactable in grabInteractables)
        {
            interactable.selectEntered.RemoveAllListeners();
            interactable.selectExited.RemoveAllListeners();
            interactable.activated.RemoveAllListeners();
        }
    }

    private void Activated(ActivateEventArgs arg0)
    {
        Debug.Log(arg0.interactorObject.transform.name + " ha activat " + arg0.interactableObject.transform.name);
        if (true)
            arg0.interactableObject.transform.GetComponent<Renderer>().material = materials[1];
        else
            arg0.interactableObject.transform.GetComponent<Renderer>().material = materials[0];
    }

    private void Exit(SelectExitEventArgs arg0)
    {

        Debug.Log(arg0.interactorObject.transform.parent.name + " ha amollat " + arg0.interactableObject.transform.name);
        arg0.interactableObject.transform.GetComponent<Renderer>().material = materials[2];
        arg0.interactorObject.transform.parent.GetComponentInChildren<Renderer>().material = materials[4];
    }

    private void Selected(SelectEnterEventArgs arg0)
    {

        Debug.Log(arg0.interactorObject.transform.parent.name + " ha agafat " + arg0.interactableObject.transform.name);
        arg0.interactorObject.transform.parent.GetComponentInChildren<Renderer>().material = materials[3];
        arg0.interactableObject.transform.GetComponent<Renderer>().material = materials[0];
    }
}
