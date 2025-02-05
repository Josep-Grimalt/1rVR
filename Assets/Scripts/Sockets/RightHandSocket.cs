using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class RightHandSocket : XRSocketInteractor
{
    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        RightHandOnly rightHandOnly = interactable.transform.GetComponent<RightHandOnly>(); 

        return rightHandOnly != null && rightHandOnly.IsRightHandHeld();   
    }
}
