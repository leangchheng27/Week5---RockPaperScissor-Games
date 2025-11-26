using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public AudioClip playSound;
    public AudioClip tutorialSound;
    public TextMeshProUGUI titleText;
    public float bounceSpeed = 2f;
    public float bounceHeight = 20f;

    void Start()
    {
        if (titleText != null)
        {
            StartCoroutine(BounceAnimation());
        }
    }

    public void PlayGame()
    {
        PlaySound(playSound);
        Invoke("LoadPlayScene", 0.3f);
    }

    public void PlayTutorial()
    {
        PlaySound(tutorialSound);
        Invoke("LoadTutorialScene", 0.3f);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogWarning("Sound clip not assigned!");
            return;
        }

        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    private void LoadPlayScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void LoadTutorialScene()
    {
        SceneManager.LoadScene("Tutorial");
    }

    private IEnumerator BounceAnimation()
    {
        Vector3 originalPosition = titleText.transform.localPosition;
        Quaternion originalRotation = titleText.transform.localRotation;
        
        while (true)
        {
            float elapsed = 0f;
            while (elapsed < 1f / bounceSpeed)
            {
                // Bouncing motion
                float newY = originalPosition.y + Mathf.Sin(elapsed * bounceSpeed * Mathf.PI) * bounceHeight;
                
                // Swing rotation (left and right equally)
                float rotation = Mathf.Sin(elapsed * bounceSpeed * Mathf.PI * 2) * 15f;
                
                titleText.transform.localPosition = new Vector3(originalPosition.x, newY, originalPosition.z);
                titleText.transform.localRotation = Quaternion.Euler(0, 0, rotation);
                
                elapsed += Time.deltaTime;
                yield return null;
            }
            
            // Reset
            titleText.transform.localPosition = originalPosition;
            titleText.transform.localRotation = originalRotation;
            yield return new WaitForSeconds(0.3f);
        }
    }
}
