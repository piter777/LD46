using UnityEngine;

public class InteractebleObject : MonoBehaviour
{
    public bool active = true;
    public bool working = false;
    public string colliderText;
    public int wiresCost;
    public int micCost;
    public int metalCost;
    public int lastTick = 0;
    public int gameenginetick = 0;
    public int engineticl;
    public int powerConscuption = 0;

    public virtual void OnTriggerStay(Collider other)
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
                        gameenginetick = GameEngine.gameEngine.tick+1;
                        GameEngine.gameEngine.InteractionText.text = "";
                        RemoveItems();
                       
                    }

                }
            }
            else
            {

                if (active)
                {
                    GameEngine.gameEngine.InteractionText.text = "Shot down";

                    if (Input.GetKey(KeyCode.E) && (gameenginetick < GameEngine.gameEngine.tick))
                    {
                        active = false;
                        GameEngine.gameEngine.InteractionText.text = "Power on";
                        gameenginetick = GameEngine.gameEngine.tick;

                    }

                }
                else
                {
                    GameEngine.gameEngine.InteractionText.text = "Power on";

                    if (Input.GetKey(KeyCode.E) && (gameenginetick < GameEngine.gameEngine.tick))
                    {
                        active = true;
                        GameEngine.gameEngine.InteractionText.text = "Shot Down";
                        gameenginetick = GameEngine.gameEngine.tick;

                    }

                }


            }


        }

    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameEngine.gameEngine.InteractionText.text = "";
        }

    }
    public virtual void Interact()
    {
       
        working = true;
        active = true;
    }
    private void Update()
    {
       
        if ((working) && (active)&& (GameEngine.gameEngine.batteryCharge > powerConscuption))
        {
            PowerUsage(powerConscuption);
         

        }
        if ((working) && (active) && (GameEngine.gameEngine.batteryCharge <= powerConscuption))
        {
            active = false;

        }

        
       
    }
    
       

    

    public virtual void RemoveItems()
    {
        GameEngine.gameEngine.metalCount -= metalCost;
        GameEngine.gameEngine.micCount -= micCost;
        GameEngine.gameEngine.wiresCount -= wiresCost;
    }

    public virtual void PowerUsage(int power)
    {
      

                if (lastTick < GameEngine.gameEngine.tick)
                {
                    GameEngine.gameEngine.ChangeCharge(-power);
                    lastTick = GameEngine.gameEngine.tick;
            UpdateTick();
        }
      
    }

    public virtual void UpdateTick()
    {
  
    }
    public virtual void Broke()
    {
       // GameEngine.gameEngine.maxBattaryCharge -= 50;
        working = false;
    }
}
