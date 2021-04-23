using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    public bool isPaused = false;
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

    // Update is called once per frame
    void Update()
    {
        
    }


}
