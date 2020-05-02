using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixZRotation : MonoBehaviour
{
    public bool rotate = true;
    public float speed = 0.01f;

    // Update is called once per frame
    void LateUpdate()
    {
       
        if((!GameEngine.gameEngine.engineWork)&&(Time.timeScale==1f))
       this.transform.Rotate(0.0f, speed, 0.0f);
      
    }
}
