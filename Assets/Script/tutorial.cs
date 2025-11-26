using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class tutorial : MonoBehaviour
{
    public AudioClip tutorialSound;

    public void tutorialPage()
    {
        PlaySound(tutorialSound);
        Invoke("LoadTutorialScene", 0.3f);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogWarning("Tutorial sound clip not assigned!");
            return;
        }

        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    private void LoadTutorialScene()
    {
        SceneManager.LoadSceneAsync("Tutorial");
    }
}
