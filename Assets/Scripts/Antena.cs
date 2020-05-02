using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antena : InteractebleObject
{
    
    
    public override void Interact()
    {
        this.gameObject.GetComponent<Light>().range = 10f;
        working = true;
    }

    public override void UpdateTick()
    {
        if ((working) && (active))
        {
            this.gameObject.GetComponent<Light>().range = 10f;
            GameEngine.gameEngine.antenaCharge++;
            
        }
        else
            this.gameObject.GetComponent<Light>().range = 0f;
    }
}
