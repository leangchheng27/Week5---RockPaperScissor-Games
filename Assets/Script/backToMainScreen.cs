using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class backToMainScreen : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }
}
