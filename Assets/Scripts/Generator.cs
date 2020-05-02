using UnityEngine;

public class Generator : InteractebleObject
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
        }
        else
        {
            this.gameObject.GetComponent<Light>().range = 0f;
          
        }
           
    }
}
