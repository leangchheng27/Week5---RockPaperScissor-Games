using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image ImgYou, ImgCom;
    public TMP_Text TextYou, TextCom;
    public TMP_Text ResultText; // Assign this in the Inspector to your center result message
    public Sprite[] handSprites; // 0: Rock, 1: Paper, 2: Scissors
    int playerScore = 0, computerScore = 0;
    private const int WINNING_SCORE = 5; // First to 5 points wins

    void Start()
    {
        // Initialize scores on start
        if (TextYou != null) TextYou.text = "0";
        if (TextCom != null) TextCom.text = "0";
        
        // Debug to check if everything is assigned
        Debug.Log("ImgYou assigned: " + (ImgYou != null));
        Debug.Log("ImgCom assigned: " + (ImgCom != null));
        Debug.Log("TextYou assigned: " + (TextYou != null));
        Debug.Log("TextCom assigned: " + (TextCom != null));
        Debug.Log("HandSprites count: " + (handSprites != null ? handSprites.Length : 0));
    }

    public void OnPlayerChoice(int playerChoice)
    {
        // Validate inputs
        if (handSprites == null || handSprites.Length < 3)
        {
            Debug.LogError("HandSprites array is not properly set! Please assign 3 sprites (Rock, Paper, Scissors) in the Inspector.");
            return;
        }

        if (ImgYou == null || ImgCom == null)
        {
            Debug.LogError("ImgYou or ImgCom is not assigned in the Inspector!");
            return;
        }

        int computerChoice = Random.Range(1, 4);
        
        Debug.Log("Player chose: " + playerChoice + ", Computer chose: " + computerChoice);

        // Update images
        ImgYou.sprite = handSprites[playerChoice - 1];
        ImgCom.sprite = handSprites[computerChoice - 1];
        
        // Make sure images are enabled
        ImgYou.enabled = true;
        ImgCom.enabled = true;

        int k = playerChoice - computerChoice;

        if (k == 0)
        {
            if (ResultText != null) ResultText.text = "Draw!";
        }
        else if (k == 1 || k == -2)
        {
            playerScore++;
            if (ResultText != null) ResultText.text = "You Win!";
        }
        else
        {
            computerScore++;
            if (ResultText != null) ResultText.text = "Computer Wins!";
        }

        // Update score texts
        if (TextYou != null) TextYou.text = playerScore.ToString();
        if (TextCom != null) TextCom.text = computerScore.ToString();
        
        Debug.Log("Score - You: " + playerScore + ", Computer: " + computerScore);
        
        // Check for winning condition
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (playerScore >= WINNING_SCORE)
        {
            Debug.Log("Player wins the game!");
            SceneManager.LoadScene("WeWin");
        }
        else if (computerScore >= WINNING_SCORE)
        {
            Debug.Log("Computer wins the game!");
            SceneManager.LoadScene("BotWin");
        }
    }

    public void ResetGame()
    {
        playerScore = 0;
        computerScore = 0;
        if (TextYou != null) TextYou.text = "0";
        if (TextCom != null) TextCom.text = "0";
        if (ResultText != null) ResultText.text = "";
        Debug.Log("Game reset!");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}