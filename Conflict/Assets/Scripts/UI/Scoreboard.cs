using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Scoreboard : MonoBehaviour
{

    public TextMeshProUGUI Player1ScoreText;
    public TextMeshProUGUI Player2ScoreText;
    public TextMeshProUGUI WinText;

    public string Player1WinString = "Player 1 Wins!";
    public string Player2WinString = "Player 2 Wins!";

    public void UpdatePlayerScores(int player1Score, int player2Score)
    {
        Player1ScoreText.text = player1Score.ToString();
        Player2ScoreText.text = player2Score.ToString();
    }

    public void DeclareWinner(string winText)
    {
        WinText.text = winText;
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    

}
