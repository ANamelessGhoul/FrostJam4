using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DemonNavMesh : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    
    private NavMeshAgent _navMeshAgent;

    private bool _areLightsOn = true;

    private bool _isInView = false;
    public bool IsInView 
    { 
        get => _isInView; 
        set 
        {
            _isInView = value;
            UpdateStopped();
        } 
    }

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_isInView && _areLightsOn)
            return;
        _navMeshAgent.destination = targetTransform.position;
    }

    public void OnAreLightsOnChanged(bool areLightsOn) 
    {
        _areLightsOn = areLightsOn;
        UpdateStopped();
    }

    public void UpdateStopped() 
    {
        _navMeshAgent.isStopped = _isInView && _areLightsOn;
    }
}
