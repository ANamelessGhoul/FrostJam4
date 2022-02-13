using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewArea : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private LayerMask viewOccluderMask;
    private List<DemonNavMesh> _demonsInViewArea = new List<DemonNavMesh>();

    private void FixedUpdate()
    {
        foreach (DemonNavMesh demon in _demonsInViewArea) 
        {
            var difference = demon.transform.position - player.transform.position;
            if (Physics.Raycast(player.transform.position, difference, out var hit, difference.magnitude, viewOccluderMask)) 
            {
                bool isHitObjectDemon = hit.transform.gameObject == demon.gameObject;
                demon.IsInView = isHitObjectDemon;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<DemonNavMesh>(out var demonNavMesh)) 
        {
            _demonsInViewArea.Add(demonNavMesh);

            demonNavMesh.IsInView = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<DemonNavMesh>(out var demonNavMesh))
        {
            _demonsInViewArea.Remove(demonNavMesh);

            demonNavMesh.IsInView = false;
        }
    }
}
