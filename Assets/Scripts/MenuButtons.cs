using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtons : MonoBehaviour
{
    public void OnStartButtonPressed()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(5);
        GameObject.FindWithTag("MusicManager").GetComponent<MusicManager>().changeMusic();
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("GameplayLevel");
    }

    public void OnCreditsButtonPressed()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(5);
        SceneManager.LoadScene("Credits");
    }

    public void OnInstructionsButtonPressed()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(5);
        SceneManager.LoadScene("Instructions");
    }

    public void OnExitButtonPressed()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(5);
        Application.Quit();
    }

    public void OnBackButtonPressed()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(5);
        GameObject.FindWithTag("MusicManager").GetComponent<MusicManager>().changeMusic();
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
    }

    public void OnResumeButtonPressed()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(5);
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().Pause(false);
    }
}
