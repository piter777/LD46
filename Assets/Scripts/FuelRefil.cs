using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelRefil : InteractebleObject
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
            else
            {

               
                    GameEngine.gameEngine.InteractionText.text = "Refill fuel 10 for 20 energy";

                    if (Input.GetKey(KeyCode.E) && (gameenginetick < GameEngine.gameEngine.tick))
                    {
                    GameEngine.gameEngine.fuel += 10;
                    GameEngine.gameEngine.batteryCharge -= 20;
                    GameEngine.gameEngine.InteractionText.text = "Done";
                        gameenginetick = GameEngine.gameEngine.tick;

                    }

                }
            }
    }
    public override void Interact()
    {



        gameenginetick = GameEngine.gameEngine.tick;
        working = true;


    }


    public override void Broke()
    {
   
        working = false;
    }
}
