using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip collision;
    public AudioClip gravUp;
    public AudioClip gravDown;
    public AudioClip gravRev;
    public AudioClip uiButton;
    public AudioClip hudButton;
    public AudioClip victory;
    void Start()
    {
        DontDestroyOnLoad(this);
        if (GameObject.FindGameObjectsWithTag("SoundManager").Length > 1)
        {
            Destroy(GameObject.FindGameObjectsWithTag("SoundManager")[1]);
        }
    }

    public void PlaySound(int i)
    {
        if (i == 1)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(collision);
        }
        else if (i == 2)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(gravUp);
        }
        else if (i == 3)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(gravDown);
        }
        else if (i == 4)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(gravRev);
        }
        else if (i == 5)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(uiButton);
        }
        else if (i == 6)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(hudButton);
        }
        else if (i == 7)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(victory);
        }
    }
}
