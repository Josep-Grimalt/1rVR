using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private int magCapacity;
    [SerializeField] private XRSocketInteractor magSocket;
    [SerializeField] private InputActionProperty leftReleaseButton, rightReleaseButton;

    private int mag;
    private XRGrabInteractable grabbable;
    private bool isLeftHand, leftHandButton, rightHandButton;

    void Awake()
    {
        mag = 0;
        isLeftHand = false;
        leftHandButton = false;
        rightHandButton = false;

        grabbable = GetComponent<XRGrabInteractable>();
    }

    void OnEnable()
    {
        grabbable.selectEntered.AddListener(Grabbed);
        magSocket.selectEntered.AddListener(Loaded);
        magSocket.selectExited.AddListener(ReleaseMag);

        leftReleaseButton.action.started += LeftHandReload;
        rightReleaseButton.action.started += RightHandReload;
        leftReleaseButton.action.canceled += NoButton;
        rightReleaseButton.action.canceled += NoButton;
    }

    private void ReleaseMag(SelectExitEventArgs arg0)
    {
        Debug.Log("Mag released");

        if (mag < 1) mag = 0;
        else mag = 1;

        magSocket.allowSelect = true;

        var interactable = magSocket.GetOldestInteractableSelected();
        if (interactable != null)
        {
            Transform magTransform = interactable.transform;
            magTransform.parent = null;

            if (magTransform.TryGetComponent<Rigidbody>(out var rb))
                rb.isKinematic = false;

            Destroy(magTransform.gameObject, 30f);
        }
    }

    private void Loaded(SelectEnterEventArgs arg0)
    {
        var interactable = magSocket.GetOldestInteractableSelected();
        if (interactable != null)
        {
            Rigidbody rb = interactable.transform.GetComponent<Rigidbody>();
            if (rb != null) rb.isKinematic = true;
        }
        Reload();
    }

    void Update()
    {
        if ((leftHandButton && isLeftHand) || (rightHandButton && !isLeftHand))
        {
            ReleaseMag(new SelectExitEventArgs());
        }
    }

    private void OnDisable()
    {
        grabbable.selectEntered.RemoveAllListeners();
        magSocket.selectEntered.RemoveListener(Loaded);
        magSocket.selectExited.RemoveAllListeners();

        leftReleaseButton.action.started -= LeftHandReload;
        rightReleaseButton.action.started -= RightHandReload;
        leftReleaseButton.action.canceled -= NoButton;
        rightReleaseButton.action.canceled -= NoButton;
    }

    public void Shot()
    {
        if (mag > 0)
        {
            mag--;

            GameObject go = Instantiate(bullet, shootingPoint.position, shootingPoint.rotation); // 🔹 Ara es dispara correctament
            Destroy(go, 2f);
        }

        if (mag <= 0)
        {
            ReleaseMag();
        }
    }

    private void ReleaseMag()
    {
        magSocket.allowSelect = true;

        var interactable = magSocket.GetOldestInteractableSelected();
        if (interactable != null)
        {
            Transform magTransform = interactable.transform;
            magTransform.parent = null;

            if (magTransform.TryGetComponent<Rigidbody>(out var rb))
                rb.isKinematic = false;

            Destroy(magTransform.gameObject, 30f);
        }
    }

    public void Reload()
    {
        if (mag < 1) mag = magCapacity;
        else mag = magCapacity + 1;
    }

    private void Grabbed(SelectEnterEventArgs arg0)
    {
        isLeftHand = arg0.interactorObject.handedness.ToString().Equals("Left");
    }

    private void NoButton(InputAction.CallbackContext context)
    {
        leftHandButton = false;
        rightHandButton = false;
    }

    private void RightHandReload(InputAction.CallbackContext context)
    {
        leftHandButton = false;
        rightHandButton = true;
    }

    private void LeftHandReload(InputAction.CallbackContext context)
    {
        rightHandButton = false;
        leftHandButton = true;
    }
}
