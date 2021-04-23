using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    public bool isPaused = false;
    public GameObject respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas.SetActive(false);
    }

    public void Pause(bool paused)
    {
        if(paused)
        {
            isPaused = true;
            pauseCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().cameraLock = true;
        }
        else
        {
            isPaused = false;
            pauseCanvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().cameraLock = false;
        }
    }

    public void Victory()
    {
        SceneManager.LoadScene("EndGame");
    }

}
