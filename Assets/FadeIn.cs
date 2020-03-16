using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField]
    private Image img = null;

    void Start()
    {
        StartCoroutine(FadeImage());
    }

    IEnumerator FadeImage()
    {
        // fade from opaque to transparent

        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }
        FindObjectOfType<GameManager>().EnterGame();

    }

}
