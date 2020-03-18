using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Move playerMove = null;
    [SerializeField]
    private GameObject Fade = null;
    [SerializeField]
    private PointsController pointsController = null;
    [SerializeField]
    private SpawnController spawnController = null;
    [SerializeField]
    private TimeUI timeUI = null;
    [SerializeField]
    private CanvasGroup startOverlay = null;

    [SerializeField]
    private CanvasGroup keysOverlay = null;
    [SerializeField]
    private CanvasGroup DeathOverlay = null;

    private float score = 0.0f;
    private bool FirstTry = true;

    public static bool GameIsRunning = false;


    public void EnterGame()
    {
        Fade.SetActive(false);
        pointsController.SetCallback(PlayerDied);
        Time.timeScale = 0.0f;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && GameIsRunning)
        {
            StopGame();
        }
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
        if (!FirstTry)
            ToggleCanvasGroup(DeathOverlay);
        else
            FirstTry = false;

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
        spawnController.Reset();
        pointsController.Reset();
        timeUI.Reset();
        playerMove.Reset();
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
