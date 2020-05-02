using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public float health = 1;
    
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (health < 0) 
        {
            Destroy(this.gameObject);
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {


        Vector3 collisionDir = collision.contacts[0].point - transform.position;
        float inlineSpeed = Vector3.Dot(collisionDir.normalized, rb.velocity);

        if (rb.velocity == Vector3.zero)
            inlineSpeed = collision.relativeVelocity.magnitude * 0.7f;
        if (inlineSpeed > 5)
        {
            // inert block


            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            else
            {
                if (collision.gameObject.tag == "Room")
                {
                    if (collision.gameObject.GetComponent<RoomHealth>().timer > 0.5f)
                    {
                        health -= Mathf.Abs(inlineSpeed);
                    }
                }
                else
                    health -= Mathf.Abs(inlineSpeed);
            }


                
         
        }




    }
}
