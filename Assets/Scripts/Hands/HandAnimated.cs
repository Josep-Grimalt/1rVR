using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class HandAnimated : MonoBehaviour
{
    [SerializeField] private InputActionProperty selectAction;
    [SerializeField] private InputActionProperty activateAction;
    
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("select", selectAction.action.ReadValue<float>());
        anim.SetFloat("activate", activateAction.action.ReadValue<float>());
    }
}
