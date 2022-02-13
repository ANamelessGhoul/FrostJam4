using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonChase : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<DemonNavMesh>(out var demonNavMesh))
        {
            source.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<DemonNavMesh>(out var demonNavMesh))
        {
            source.Stop();
        }
    }
}
