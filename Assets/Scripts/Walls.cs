using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
 

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {

            if (Input.GetKey(KeyCode.F))
            {
                other.attachedRigidbody.velocity = Vector3.zero;
               
            }
        }
    }
}
