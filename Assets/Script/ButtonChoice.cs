using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Image ImgYou, ImgCom;
    public TMP_Text TextYou, TextCom;
    public TMP_Text ResultText; // Assign this in the Inspector to your center result message
    public Sprite[] handSprites; // 0: Rock, 1: Paper, 2: Scissors
    public Button[] choiceButtons; // 0: Rock, 1: Paper, 2: Scissors
    public Color selectedButtonColor = Color.green;
    public Color normalButtonColor = Color.white;
    public AudioClip[] choiceAudioClips; // 0: Rock, 1: Paper, 2: Scissors
    public AudioClip winAudioClip;
    public AudioClip loseAudioClip;
    public AudioClip drawAudioClip;
    private AudioSource audioSource;
    int playerScore = 0, computerScore = 0;
    private const int WINNING_SCORE = 5; // First to 5 points wins

    void Start()
    {
        // Initialize scores on start
        if (TextYou != null) TextYou.text = "0";
        if (TextCom != null) TextCom.text = "0";
        
        // Get AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        
        // Start continuous shaking for all images
        if (ImgYou != null) StartCoroutine(ContinuousShake(ImgYou));
        if (ImgCom != null) StartCoroutine(ContinuousShake(ImgCom));
        
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

        // Highlight the clicked button
        HighlightButton(playerChoice);

        // Play choice sound
        PlayChoiceSound(playerChoice);

        int computerChoice = Random.Range(1, 4);
        
        Debug.Log("Player chose: " + playerChoice + ", Computer chose: " + computerChoice);

        // Update images
        ImgYou.sprite = handSprites[playerChoice - 1];
        ImgCom.sprite = handSprites[computerChoice - 1];
        
        // Make sure images are enabled
        ImgYou.enabled = true;
        ImgCom.enabled = true;

        // Start shake animations for both images
        StartCoroutine(ShakeImage(ImgYou));
        StartCoroutine(ShakeImage(ImgCom));

        int k = playerChoice - computerChoice;

        if (k == 0)
        {
            if (ResultText != null) ResultText.text = "Draw!";
            PlayResultSound(drawAudioClip);
        }
        else if (k == 1 || k == -2)
        {
            playerScore++;
            if (ResultText != null) ResultText.text = "You Win!";
            PlayResultSound(winAudioClip);
        }
        else
        {
            computerScore++;
            if (ResultText != null) ResultText.text = "Computer Wins!";
            PlayResultSound(loseAudioClip);
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

    private IEnumerator ShakeImage(Image image)
    {
        Vector3 originalPosition = image.transform.localPosition;
        float shakeDuration = 0.5f;
        float shakeAmount = 10f;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float randomX = Random.Range(-shakeAmount, shakeAmount);
            float randomY = Random.Range(-shakeAmount, shakeAmount);
            
            image.transform.localPosition = originalPosition + new Vector3(randomX, randomY, 0);
            
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Reset to original position
        image.transform.localPosition = originalPosition;
    }

    private IEnumerator ContinuousShake(Image image)
    {
        Vector3 originalPosition = image.transform.localPosition;
        float shakeAmount = 3f; // Smaller shake for continuous effect

        while (true)
        {
            float randomX = Random.Range(-shakeAmount, shakeAmount);
            float randomY = Random.Range(-shakeAmount, shakeAmount);
            
            image.transform.localPosition = originalPosition + new Vector3(randomX, randomY, 0);
            
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void PlayChoiceSound(int choice)
    {
        if (audioSource == null || choiceAudioClips == null || choiceAudioClips.Length < 3)
        {
            Debug.LogWarning("AudioSource or choiceAudioClips not properly assigned!");
            return;
        }

        audioSource.PlayOneShot(choiceAudioClips[choice - 1]);
    }

    private void PlayResultSound(AudioClip clip)
    {
        if (audioSource == null || clip == null)
        {
            Debug.LogWarning("AudioSource or result sound clip not assigned!");
            return;
        }

        audioSource.PlayOneShot(clip);
    }

    private void HighlightButton(int buttonIndex)
    {
        if (choiceButtons == null || choiceButtons.Length < 3)
        {
            Debug.LogWarning("Choice buttons array not properly assigned!");
            return;
        }

        // Reset all buttons to normal color
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            choiceButtons[i].image.color = normalButtonColor;
        }

        // Highlight the selected button
        choiceButtons[buttonIndex - 1].image.color = selectedButtonColor;
    }
}