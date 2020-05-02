using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Momentum : MonoBehaviour
{
    public float speed=25;
    Rigidbody rb;
    public float health=10;
    public float TimeToLive = 15f;
    public bool EvakShip = false;
  public  float dist;
    private int tickevak;
   // public Vector3 velocityBeforePhysicsUpdate;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();
        rb.velocity += transform.forward * speed;
        if(TimeToLive>0)
        Destroy(gameObject,15f);
    }

   
    // Update is called once per frame
    void Update()
    {
        if (EvakShip)
        {
            dist = Vector3.Distance(Vector3.zero, transform.position);
            if (dist < 60)
            {
                Debug.Log(dist);
                rb.velocity = rb.velocity / 5;
                rb.angularVelocity = rb.angularVelocity /5f;
                EvakShip = false;
            }

        }
        else
        {
            if ((tickevak < GameEngine.gameEngine.tick)&&(gameObject.tag!="Enemy"))
            {
                tickevak = GameEngine.gameEngine.tick;
                rb.velocity = rb.velocity / 1.5f;
                rb.angularVelocity = rb.angularVelocity / 1.5f;
            }
        }
            
        
    }


    private void OnCollisionEnter(Collision collision)
    {
       

        Vector3 collisionDir  = collision.contacts[0].point - transform.position;
        float inlineSpeed  = Vector3.Dot(collisionDir.normalized, rb.velocity);
        health -= inlineSpeed;
        if (health < 0)
        {
            Destroy(gameObject);
        }
            

    }
}
