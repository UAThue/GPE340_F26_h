using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPaused = false;
    public List<Wave> waves;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        // Set the timescale to 0
        Time.timeScale = 0.0f;

        // Set our bool
        isPaused = true;
    }

    public void UnpauseGame()
    {
        // Set the timescale to 0
        Time.timeScale = 1.0f;

        // Set our bool
        isPaused = false;
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            UnpauseGame();
        } else
        {
            PauseGame();
        }
    }


    public void SpawnPlayer()
    {
        // Choose a spawn point
        // Spawn a player controller
        // Spawn a pawn
        // Possess the pawn
    }

    public void RespawnPlayer()
    {
        // Check for lives/game over
        // Spawn the player
    }

    public void DoGameOver()
    {
        //TODO: Handle the game over scenario
    }
}
