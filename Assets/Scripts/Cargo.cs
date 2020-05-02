using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : InteractebleObject
{

  




    public override void Interact()
    {
        Destroy(this.gameObject);
        GameEngine.gameEngine.metalCount++;
        GameEngine.gameEngine.wiresCount++;
        GameEngine.gameEngine.micCount++;

    }
}
