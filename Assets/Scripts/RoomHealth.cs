using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomHealth : MonoBehaviour
{
    public float health=100;
    public bool crashHapend = false;
    public GameObject intObject;
    public GameObject player;
    public float timer = 0;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void OnPreCollisionEnter(Collision collision)
    {
        Debug.Log("111111111111111");
    }





    private void OnCollisionEnter(Collision collision)
    {

        
        Vector3 collisionDir = collision.contacts[0].point - transform.position;
        float inlineSpeed = Vector3.Dot(collisionDir.normalized, rb.velocity);
 
        if (rb.velocity == Vector3.zero)
            inlineSpeed = collision.relativeVelocity.magnitude*0.7f;

        if (inlineSpeed > 5)
        {
            // inert block
           
            if (collision.gameObject.tag != "Enemy")
            {
                if (timer > 0.5f)
                {
                    health -= Mathf.Abs(inlineSpeed);
                }
            }
            else
                health -= Mathf.Abs(inlineSpeed);
            timer = 0;
        }

        


    }


    private void Update()
    {
        timer += Time.deltaTime;
        if ((health < 0) && (!crashHapend))
        {
            Crash();
        }
         
     //   Destroy(this);
    }

    public void Crash()
    {
        
        crashHapend = true;
        rb.constraints = RigidbodyConstraints.None;
        foreach (Transform child in transform)
        {
            if (child.gameObject.GetComponent<Rigidbody>() == null)
            {
                Rigidbody childRB = child.gameObject.AddComponent<Rigidbody>();
                childRB.useGravity = false;
                childRB.constraints = RigidbodyConstraints.FreezePositionY;
            }
            else
            {
                child.gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
          
        
         
            Destroy(child.GetComponent<DoorEngine>());

            if (0 > Random.Range(-10.0f, 10.0f))
            {
                Destroy(child.gameObject, 0.1f);
            }


        }
        if (intObject != null)
        Destroy(intObject.GetComponent<InteractebleObject>() );


        if (transform.parent.name == "Ship")
            transform.SetParent(transform.parent.transform.parent);
      
       transform.DetachChildren();
        if (player != null)
            player.GetComponent<PlayerMovment>().RoomCrash();
        //destroy platfor,
        Destroy(gameObject);



    }
}
