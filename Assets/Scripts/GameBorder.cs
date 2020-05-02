using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBorder : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
    //    Destroy(collision.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
      //  Destroy(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
        if (other.tag == "Player")
        {
            GameEngine.gameEngine.Death(1);
        }
     //   Debug.Log("border collision");
    }
}
