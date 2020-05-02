using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrioCamera : MonoBehaviour
{
    
   // public GameObject crioCap;


    public void OnTriggerStay(Collider other)
    {
       
        if (other.tag == "Player")
        {


            if (GameEngine.gameEngine.cpsuleInHands == false)
            {
                GameEngine.gameEngine.InteractionText.text = "PickUpCrioCamera";

                if (Input.GetKey(KeyCode.E))
                {

                    GameEngine.gameEngine.PickUPCapsule();
                    GameEngine.gameEngine.InteractionText.text = "";
                    Destroy(gameObject);
                }
            }
           
        }
    }

    public  void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameEngine.gameEngine.InteractionText.text = "";
        }

    }
}
