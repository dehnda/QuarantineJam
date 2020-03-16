using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{

    [SerializeField]
    private Text TextTime = null;
    private bool IsStarted = false;
    private float startTime = 0.0f;
    private float stopTime = 0.0f;

    public float Result = 0.0f;

    void Update()
    {
        if (IsStarted)
        {
            var currenTime = (Time.time - startTime);
            TextTime.text = currenTime.ToString("0.0");
        }
        else
        {
            var currenTime = (stopTime - startTime);
            TextTime.text = currenTime.ToString("0.0");
        }
    }

    public void ToggleTime()
    {
        IsStarted = !IsStarted;

        if (IsStarted)
        {
            startTime = Time.time;
        }
        else
        {
            stopTime = Time.time;
            Result = (stopTime - startTime);
        }

    }

    public void Reset()
    {
        StopAllCoroutines();
        startTime = 0.0f;
        stopTime = 0.0f;
    }
}
