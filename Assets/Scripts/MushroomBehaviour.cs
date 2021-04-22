using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBehaviour : MonoBehaviour
{
    public bool gravUp;
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
                other.gameObject.GetComponent<PlayerController>().gravityScale = 1.6f;
            }
            else
            {
                other.gameObject.GetComponent<PlayerController>().gravityScale = 0.4f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().gravityScale = 1;
        }
    }
}
