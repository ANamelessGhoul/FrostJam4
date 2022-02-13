using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] private GameObject lightParent;
    [SerializeField] private float flickerProbability = 1;

    private bool _isFlickering = false;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        if (!_gameManager)
        {
            Debug.LogError("No Game Manager found!");
            gameObject.SetActive(false);
        }

        StartCoroutine(FlickerTriggerCoroutine());
    }

    private IEnumerator FlickerTriggerCoroutine() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(1.0f);
            if (!_isFlickering) 
            {
                var randomNumber = Random.Range(0, 100);
                if (randomNumber < flickerProbability) 
                {
                    _isFlickering = true;
                    StartCoroutine(BlinkCoroutine());

                    var flickerDuration = 5f;
                    yield return new WaitForSeconds(flickerDuration);
                    _isFlickering = false;
                }
            }
        }
    }

    private IEnumerator BlinkCoroutine() 
    {
        while (_isFlickering) 
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
            GameManager.Instance.AreLightsOn = !GameManager.Instance.AreLightsOn;
            lightParent.SetActive(GameManager.Instance.AreLightsOn);
        }

        GameManager.Instance.AreLightsOn = true;
        lightParent.SetActive(GameManager.Instance.AreLightsOn);
    }
}
