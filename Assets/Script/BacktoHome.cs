using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class backToHome : MonoBehaviour
{
    public AudioClip backSound;

    public void HomePage()
    {
        PlaySound(backSound);
        Invoke("LoadHomeScene", 0.3f);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogWarning("Back sound clip not assigned!");
            return;
        }

        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    private void LoadHomeScene()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
