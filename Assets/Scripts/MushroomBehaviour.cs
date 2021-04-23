using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBehaviour : MonoBehaviour
{
    public bool gravUp;
    public bool gravRev;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gravUp)
            {
                other.gameObject.GetComponent<PlayerController>().gravityScale = 2.8f;
                GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(2);
            }
            else if (gravRev)
            {
                other.gameObject.GetComponent<PlayerController>().gravityScale = -0.8f;
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
                GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(4);
            }
            else
            {
                other.gameObject.GetComponent<PlayerController>().gravityScale = 0.4f;
                GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(3);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().gravityScale = 1.4f;
        }
    }
}
