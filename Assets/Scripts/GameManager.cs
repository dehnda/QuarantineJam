using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup startOverlay = null;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
    }

    public void StartGame()
    {
        //StartCoroutine(BlendCanvasGroup(.5f));
        startOverlay.interactable = false;
        startOverlay.alpha = 0.0f;
        Time.timeScale = 1f;
    }

    //todo
    // IEnumerator BlendCanvasGroup(float duration)
    // {
    //     float elapsed = 0.0f;

    //     while (elapsed < duration)
    //     {
    //         startOverlay.alpha -= duration / 100;

    //         elapsed += Time.deltaTime;
    //         yield return null;
    //     }

    //     startOverlay.interactable = false;
    //     startOverlay.alpha = 0.0f;
    //     Time.timeScale = 1;
    // }
}
