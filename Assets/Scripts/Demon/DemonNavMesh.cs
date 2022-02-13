using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DemonNavMesh : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    
    private NavMeshAgent _navMeshAgent;

    private bool _isInView = false;
    public bool IsInView 
    { 
        get => _isInView; 
        set 
        {
            _isInView = value;
            _navMeshAgent.isStopped = _isInView;
        } 
    }

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (IsInView)
            return;
        _navMeshAgent.destination = targetTransform.position;
    }
}
