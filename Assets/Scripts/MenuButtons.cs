using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtons : MonoBehaviour
{
    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("GameplayLevel");
    }

    public void OnCreditsButtonPressed()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnExitButtonPressed()
    {
        Application.Quit();
    }

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnResumeButtonPressed()
    {
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().Pause(false);
    }
}
