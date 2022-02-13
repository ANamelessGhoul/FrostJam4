using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] private GameObject lightParent;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        if (!_gameManager)
        {
            Debug.LogError("No Game Manager found!");
            gameObject.SetActive(false);
        }

        StartCoroutine(BlinkCoroutine());
    }
    private IEnumerator BlinkCoroutine() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(1.0f);
            GameManager.Instance.AreLightsOn = !GameManager.Instance.AreLightsOn;
            lightParent.SetActive(GameManager.Instance.AreLightsOn);
        }
    }
}
