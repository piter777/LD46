using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : InteractebleObject
{

    public override void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {


            if (!working)
            {
                GameEngine.gameEngine.InteractionText.text = colliderText;

                if (Input.GetKey(KeyCode.E))
                {
                    if ((GameEngine.gameEngine.metalCount >= metalCost) && (GameEngine.gameEngine.micCount >= micCost) && (GameEngine.gameEngine.wiresCount >= wiresCost))
                    {
                        Interact();
                        GameEngine.gameEngine.InteractionText.text = "";
                        RemoveItems();
                    }

                }
            }
        }
    }
    public override void Interact()
    {



        GameEngine.gameEngine.maxBattaryCharge += 50;
        working = true;


    }


    public override void Broke()
    {
        GameEngine.gameEngine.maxBattaryCharge -= 50;
        working = false;
    }


}
