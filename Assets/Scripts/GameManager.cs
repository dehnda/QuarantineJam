using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PointsController pointsController = null;
    [SerializeField]
    private TimeUI timeUI = null;
    [SerializeField]
    private CanvasGroup startOverlay = null;

    [SerializeField]
    private CanvasGroup keys = null;

    private float score = 0.0f;

    private bool GameIsRunning = false;


    void Start()
    {
        pointsController.SetCallback(PlayerDied);
        Time.timeScale = 0.0f;
    }

    private void PlayerDied()
    {
        StopGame();
        print("Game stopped Gamemanager");
    }


    public void StartGame()
    {
        ToggleCanvasGroup(startOverlay);
        ToggleCanvasGroup(keys);

        Time.timeScale = 1f;
        GameIsRunning = true;
        pointsController.StartPointsController();
        timeUI.ToggleTime();
    }

    public void StopGame()
    {
        ToggleCanvasGroup(startOverlay);
        ToggleCanvasGroup(keys);

        Time.timeScale = 0f;
        timeUI.ToggleTime();
        score = timeUI.Result;
        GameIsRunning = false;

        ResetGameData();
    }

    private void ResetGameData()
    {
        pointsController.Reset();
        timeUI.Reset();
    }

    private void ToggleCanvasGroup(CanvasGroup canvasGroup)
    {
        canvasGroup.interactable = !canvasGroup.interactable;
        if (canvasGroup.alpha < 0.1f)
            canvasGroup.alpha = 1f;
        else
            canvasGroup.alpha = 0.0f;
    }

}
