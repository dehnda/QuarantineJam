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
    private CanvasGroup keysOverlay = null;
    [SerializeField]
    private CanvasGroup DeathOverlay = null;

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
    }


    public void StartGame()
    {
        ResetGameData();

        ToggleCanvasGroup(startOverlay);
        ToggleCanvasGroup(keysOverlay);

        Time.timeScale = 1f;
        GameIsRunning = true;
        pointsController.StartPointsController();
        timeUI.ToggleTime();
    }

    public void StopGame()
    {
        ToggleCanvasGroup(startOverlay);
        ToggleCanvasGroup(keysOverlay);
        ToggleCanvasGroup(DeathOverlay);

        Time.timeScale = 0f;
        timeUI.ToggleTime();
        score = timeUI.Result;
        GameIsRunning = false;
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
