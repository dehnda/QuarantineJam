using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private GameObject fruitPrefab = null;
    [SerializeField]
    private GameObject junkPrefab = null;
    [SerializeField]
    private float timeToNextSpawn = 5f;
    [SerializeField]
    bool GameIsRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        GameIsRunning = true;
        StartCoroutine("InstantiateFruitRoutine");
        StartCoroutine("InstantiateJunkRoutine");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator InstantiateJunkRoutine()
    {
        while (GameIsRunning)
        {

            yield return new WaitForSeconds(timeToNextSpawn);

            var leftPos = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f));
            var rightPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));

            var position = new Vector3(Random.Range(leftPos.x, rightPos.x), leftPos.y + 1f);
            Instantiate(junkPrefab, position, Quaternion.identity);
        }
    }

    IEnumerator InstantiateFruitRoutine()
    {
        while (GameIsRunning)
        {

            yield return new WaitForSeconds(timeToNextSpawn);
            var position = new Vector3(Random.Range(-8f, 9f), 5f);
            Instantiate(fruitPrefab, position, Quaternion.identity);
        }
    }
}
