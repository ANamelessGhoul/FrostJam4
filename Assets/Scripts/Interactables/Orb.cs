using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Destroy(gameObject);
        GameManager.Instance.Win();
    }
}
