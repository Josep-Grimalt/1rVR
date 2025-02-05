using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class LeftHandSocket : XRSocketInteractor
{
    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        LeftHandOnly leftHandOnly = interactable.transform.GetComponent<LeftHandOnly>(); 

        return leftHandOnly != null && leftHandOnly.IsLeftHandHeld();   
    }
}
