using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointsController : MonoBehaviour
{
    [SerializeField]
    private PointsUI pointsUI = null;
    [SerializeField]
    private TimeUI timeUI = null;
    [SerializeField]
    private float startPoints = 100f;
    [SerializeField]
    private float curentPoints = 100f;

    [SerializeField]
    private float startDecreaseAmount = 5f;
    private float currentDecreaseAmount = 5f;
    [SerializeField]
    private float decreaseTime = 1f;


    private bool IsActive = false;

    UnityEvent playerDiedEvent = new UnityEvent();


    public void SetCallback(UnityAction call)
    {
        playerDiedEvent.AddListener(call);
    }

    public void Reset()
    {
        StopAllCoroutines();
        curentPoints = startPoints;
        currentDecreaseAmount = startDecreaseAmount;
    }


    public void StartPointsController()
    {
        StartCoroutine(DecreasePointsOverTimeRoutine());
        IsActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActive)
        {
            if (curentPoints < 0.0f)
            {
                IsActive = false;
                playerDiedEvent.Invoke();
            }
            pointsUI.SetPoints(curentPoints);
        }
    }

    public void AddPoints(float points)
    {
        curentPoints += points;
        curentPoints = Mathf.Min(curentPoints, startPoints);

        if (curentPoints <= 0)
        {
            SoundManagerScript.PlaySound(Sounds.DEATH);
        }
    }

    IEnumerator DecreasePointsOverTimeRoutine()
    {
        while (IsActive)
        {
            yield return new WaitForSeconds(decreaseTime);
            curentPoints -= currentDecreaseAmount;
        }

    }
}
