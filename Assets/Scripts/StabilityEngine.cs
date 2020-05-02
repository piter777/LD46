using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabilityEngine : InteractebleObject
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
            GameEngine.gameEngine.engineWork = true;
            this.gameObject.GetComponent<Light>().range = 10f;
        }
        else
        {
            this.gameObject.GetComponent<Light>().range = 0f;
            GameEngine.gameEngine.engineWork = false;
        }

    }
}
