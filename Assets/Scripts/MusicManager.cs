using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip gameBGM;
    public AudioClip menuBGM;
    bool menuMusic = true;

    private void Start()
    {
        DontDestroyOnLoad(this);
        if (GameObject.FindGameObjectsWithTag("MusicManager").Length > 1)
        {
            Destroy(GameObject.FindGameObjectsWithTag("MusicManager")[1]);
        }
    }

    public void changeMusic()
    {
        if (menuMusic && SceneManager.GetActiveScene().name == "MainMenu")
        {
            gameObject.GetComponent<AudioSource>().clip = gameBGM;
            menuMusic = false;
            gameObject.GetComponent<AudioSource>().Play();
        }
        else if (SceneManager.GetActiveScene().name == "GameplayLevel" || SceneManager.GetActiveScene().name == "EndGame")
        {
            gameObject.GetComponent<AudioSource>().clip = menuBGM;
            menuMusic = true;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
