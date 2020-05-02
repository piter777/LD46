using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueSHip : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player") && (GameEngine.gameEngine.cpsuleInHands == true))
        {

            GameEngine.gameEngine.TeleportCapsule();
        }

    
    }

    public void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {


           
                GameEngine.gameEngine.InteractionText.text = "Telerot Self";

                if (Input.GetKey(KeyCode.E))
                {

                      GameEngine.gameEngine.Win();
                 
                   
                }
            

        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameEngine.gameEngine.InteractionText.text = "";
        }

    }

}
