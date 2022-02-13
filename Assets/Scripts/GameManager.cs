using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private bool areLightsOn = false;
    public UnityEvent<bool> areLightsOnChanged;

    public bool AreLightsOn
    {
        get => areLightsOn;
        set
        {
            if (areLightsOn == value)
                return;

            areLightsOn = value;
            areLightsOnChanged.Invoke(areLightsOn);
        }
    }


    [SerializeField] private bool hasKey = false;
    public UnityEvent<bool> hasKeyChanged;

    public bool HasKey
    {
        get => hasKey;
        set
        {
            if (hasKey == value)
                return;

            hasKey = value;
            hasKeyChanged.Invoke(hasKey);
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
