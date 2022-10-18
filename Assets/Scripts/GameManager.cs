using System.Collections;                // Manager of the game 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private float gameLengthSeconds = 10f;
    [SerializeField] private Text scoreText;   // shows score
    [SerializeField] private Text timerText;  
    [SerializeField] GameObject gameStateUI;

    public static bool gameStarted = false;
    public static int score;
    private float timer;
    private Text gameStateText;
    private Animator gameStateTextAnimator;

    void Start()
    {
        gameStateText = gameStateUI.GetComponent<Text>();
        
        gameStateText.text = "Press space to play!";

        gameStateTextAnimator = gameStateUI.GetComponent<Animator>();
        gameStateTextAnimator.SetBool("ShowText", true);

        timer = gameLengthSeconds;

        UpdateScoreBoard();
    }

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

    private void UpdateScoreBoard()
    {
        scoreText.text = score + "Targets"; // 

        timerText.text = Mathf.RoundToInt(timer) + "Seconds"; // math func converts float to int
    }
    private void StartGame()
    {
        score = 0;
        gameStarted = true; // Starts the game 
        gameStateTextAnimator.SetBool("ShowText", false); // Makes the text disappear
    }
    private void EndGame()
    {
        gameStateText.text = "Game Over!\nPress Space to Play";
        gameStateTextAnimator.SetBool("ShowText", true);
        gameStarted = false; // Ends the game
        timer = gameLengthSeconds; // resets the time
    }
}
