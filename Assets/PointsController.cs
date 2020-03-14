using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    [SerializeField]
    private float startPoints = 100f;
    [SerializeField]
    private float curentPoints = 100f;
    [SerializeField]
    private bool GameIsRunning = false;
    [SerializeField]
    private float decreaseAmount = 5f;
    [SerializeField]
    private float decreaseTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        GameIsRunning = true;
        StartCoroutine("DecreasePointsOverTimeRoutine");
    }

    // Update is called once per frame
    void Update()
    {
        if (curentPoints < 0)
        {
            StopAllCoroutines();
            print("you Died");
        }
    }

    public void AddPoints(float points)
    {
        curentPoints += points;
        curentPoints = Mathf.Min(curentPoints, startPoints);
    }

    IEnumerator DecreasePointsOverTimeRoutine()
    {
        while (GameIsRunning)
        {
            yield return new WaitForSeconds(decreaseTime);
            curentPoints -= decreaseAmount;
        }

    }
}
