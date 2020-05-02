using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEngine : MonoBehaviour
{
  private bool playerNeaby=false;

    // Update is called once per frame
    void Update()
    {
        if (playerNeaby)
            this.transform.position = new Vector3(this.transform.position.x, -3, this.transform.position.z);
        else
            this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            playerNeaby = true;
            
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

            playerNeaby = false;

        }
    }
    
   


}
