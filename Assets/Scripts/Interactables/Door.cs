using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private bool isOpen;
    [SerializeField] private bool isLocked;
    [SerializeField] private Collider[] playerColliders;
    private Animator _doorAnim;

    private void Awake()
    {
        _doorAnim = GetComponent<Animator>();
        _doorAnim.SetBool("isOpen", isOpen);
        foreach (Collider playerCollider in playerColliders)
            playerCollider.enabled = !isOpen;

    }

    public void Interact()
    {
        if (isLocked && !GameManager.Instance.HasKey)
        {
            return;
        }
        isOpen = !isOpen;
        _doorAnim.SetBool("isOpen", isOpen);
        foreach (Collider playerCollider in playerColliders)
            playerCollider.enabled = !isOpen;
    }
}
