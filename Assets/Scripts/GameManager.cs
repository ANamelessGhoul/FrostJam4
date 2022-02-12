using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public UnityEvent<bool> hasKeyChanged;

    private bool hasKey = false;
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
