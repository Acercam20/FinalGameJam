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
                other.gameObject.GetComponent<PlayerController>().gravityScale = 1.7f;
            }
            else if (gravRev)
            {
                other.gameObject.GetComponent<PlayerController>().gravityScale = -0.6f;
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            else
            {
                other.gameObject.GetComponent<PlayerController>().gravityScale = 0.3f;
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
