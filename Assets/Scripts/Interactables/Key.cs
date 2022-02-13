using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        GameManager.Instance.HasKey = true;
        Destroy(gameObject);
    }

}
