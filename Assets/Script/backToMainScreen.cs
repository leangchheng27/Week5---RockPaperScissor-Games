using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class backToMainScreen : MonoBehaviour
{
    public AudioClip buttonClickSound;

    public void PlayAgain()
    {
        PlaySound(buttonClickSound);
        Invoke("LoadGameScene", 0.3f);
    }

    public void BackToMenu()
    {
        PlaySound(buttonClickSound);
        Invoke("LoadMenuScene", 0.3f);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogWarning("Button sound clip not assigned!");
            return;
        }

        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    private void LoadGameScene()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }

    private void LoadMenuScene()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
