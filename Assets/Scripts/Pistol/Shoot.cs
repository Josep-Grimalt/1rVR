using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

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
        mag = magCapacity + 1;
        isLeftHand = false;
        leftHandButton = false;
        rightHandButton = false;

        grabbable = GetComponent<XRGrabInteractable>();
    }

    void OnEnable()
    {
        grabbable.selectEntered.AddListener(Grabbed);

        leftReleaseButton.action.started += LeftHandReload;
        rightReleaseButton.action.started += RightHandReload;
        leftReleaseButton.action.canceled += NoButton;
        rightReleaseButton.action.canceled += NoButton;
    }

    void Update()
    {
        if ((leftHandButton && isLeftHand) ||
        (rightHandButton && !isLeftHand))
        {
            ReleaseMag();
        }
    }

    private void OnDisable()
    {
        grabbable.selectEntered.RemoveAllListeners();
    }

    public void Shot()
    {
        if (mag > 0)
        {
            mag--;
            GameObject go = Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);

            Destroy(go, 2f);
        }
    }

    public void Reload()
    {
        if (mag == 0)
        {
            mag = magCapacity;
        }
        else
        {
            mag = magCapacity + 1;
        }
    }

    public void ReleaseMag()
    {
        Debug.Log("Mag released");
        magSocket.interactablesSelected.RemoveRange(0, magSocket.interactablesSelected.Count);
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