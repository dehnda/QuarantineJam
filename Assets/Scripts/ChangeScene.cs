using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private Image img = null;

    [SerializeField]
    private float waitTime = 2f;
    [SerializeField]
    private string sceneName = "SceneToLoad";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeImage(true));
    }


    IEnumerator ChangeSceneRoutine(float wait)
    {

        yield return new WaitForSeconds(wait);
        StartCoroutine(FadeImage(false));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
            StartCoroutine(ChangeSceneRoutine(waitTime));
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
            SceneManager.LoadScene(sceneName);
        }
    }

}
