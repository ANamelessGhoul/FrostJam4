using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private bool isOpen;
    private Animator _doorAnim;

    private void Awake()
    {
        _doorAnim = GetComponent<Animator>();
        _doorAnim.SetBool("isOpen", isOpen);
    }

    public void Interact()
    {
        isOpen = !isOpen;
        _doorAnim.SetBool("isOpen", isOpen);
    }
}
