using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float forseMult = 20;
    public Rigidbody rb;
    // SerializeField
    public bool indors = false;
    public bool closeToWalls = false;
    public float timer = 1;
    public float timerInSpace = 1;
 




  

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    // Update is called once per frame
    void Update()
    {

      //  transform.position = transform.parent.position;

        //movment
        if ((indors == true))
        {
            // Indors movemnt with gravity
            timer += Time.deltaTime;
            if (timer > 0.7f)
            {
                float moveh = Input.GetAxisRaw("Horizontal");
                float movev = Input.GetAxisRaw("Vertical");
                Vector3 movement = new Vector3(moveh, 0f, movev);
                rb.velocity = movement * forseMult;
            }

        }
        else
        {
            timerInSpace += Time.deltaTime;
            //exit to space
            if (timer > 1)
            {
                timer = 0;
                rb.velocity /= 2;
                Debug.Log("Exit to space");
            }
            // charge in space
            if (Input.GetButton("Fire2")&&( timerInSpace > 0.6f)&&(GameEngine.gameEngine.fuel>0))
            {
                GameEngine.gameEngine.fuel--;
                timerInSpace = 0;
                Vector3 pos = Input.mousePosition;
                rb.velocity += transform.forward * -10;


            }

        }

        // rotation
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Vector3 turnDir = new Vector3(Input.GetAxisRaw("Mouse X"), 0f, Input.GetAxisRaw("Mouse Y"));

        turnDir = camRay.direction * -1f;

        if (turnDir != Vector3.zero)
        {
            Vector3 playerToMouse = (transform.position + turnDir) - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            this.transform.rotation = newRotation;
            // rb.MoveRotation(newRotation);
        }

    }


    //Check of indors
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Room")
        {
            indors = true;
            other.GetComponent<RoomHealth>().player = this.gameObject;
            //   transform.SetParent(other.transform);
        }
        
       
        if (other.tag == "Wall")
        {
            closeToWalls = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Room")
        {
            other.GetComponent<RoomHealth>().player = null;
            indors = false;
        
         //   transform.SetParent(null);
        }
        if (other.tag == "Wall")
        {
            closeToWalls = false;
        }
    }

   public void RoomCrash()
    {
        indors = false;
        Debug.Log("go to space");

    }

    private void OnCollisionEnter(Collision collision)
    {


        Vector3 collisionDir = collision.contacts[0].point - transform.position;
        float inlineSpeed = Vector3.Dot(collisionDir.normalized, rb.velocity);

        if (Mathf.Abs(inlineSpeed) > 8)
            GameEngine.gameEngine.Death(0);
       // Debug.Log("You got smashed "+ Mathf.Abs( inlineSpeed));
     

    }


}
