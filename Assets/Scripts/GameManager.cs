using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// TODO (2+ Responsibilities)
// GameManager tries to  manage more than one responsibility : 
//  - Game Loop (which is its own thing to do! ex. "timer")
//  - Game State
//  - Player Data
//  - UI Management
// You should split all other responsibilities into their own class
// GameManager should give order to them and should not do their jobs !
public class GameManager : MonoBehaviour
{
    // TODO (Settings)
    [SerializeField] private float gameLengthSeconds = 10f;
    // TODO (UI)
    [SerializeField] private Text scoreText;
    // TODO (UI)
    [SerializeField] private Text timerText;
    // TODO (UI)
    [SerializeField] GameObject gameStateUI;

    // TODO (State)
    public static bool gameStarted = false;
    // TODO (PlayerData)
    public static int score;
    private float timer;
    // TODO (UI)
    private Text gameStateText;
    // TODO (UI)
    private Animator gameStateTextAnimator;

    // TODO (2+ Responsibilities)
    void Start()
    {
        gameStateText = gameStateUI.GetComponent<Text>();
        
        gameStateText.text = "Press space to play!";

        gameStateTextAnimator = gameStateUI.GetComponent<Animator>();
        gameStateTextAnimator.SetBool("ShowText", true);

        timer = gameLengthSeconds;

        UpdateScoreBoard();
    }

    // TODO (2+ Responsibilities)
    // Update is called once per frame
    void Update()
    {
        if(!gameStarted && Input.GetKeyDown(KeyCode.Space)) // If game has not started yet and the 
        {                                                   // player pressing space -> start the game
            StartGame();
        }
        if (gameStarted)
        {
            // Decrement the timer
            timer -= Time.deltaTime;
            UpdateScoreBoard();
        }

        if(gameStarted && timer <= 0) // If player is out of time, end the game
        {
            EndGame();
        }
        //Escape the game, menu will be added
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


    }

    // TODO (UI) : Should be in an UIManager class
    private void UpdateScoreBoard()
    {
        scoreText.text = score + "Targets"; // 

        timerText.text = Mathf.RoundToInt(timer) + "Seconds"; // math func converts float to int
    }

    // TODO (2+ Responsibilities)
    private void StartGame()
    {
        score = 0;
        gameStarted = true; // Starts the game 
        gameStateTextAnimator.SetBool("ShowText", false); // Makes the text disappear
    }

    // TODO (2+ Responsibilities)
    private void EndGame()
    {
        gameStateText.text = "Game Over!\nPress Space to Play";
        gameStateTextAnimator.SetBool("ShowText", true);
        gameStarted = false; // Ends the game
        timer = gameLengthSeconds; // resets the time
    }
}
