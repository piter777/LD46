using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{

    public static GameEngine gameEngine;
    public Text metalText;
    public Text wiresText;
    public Text micText;
    public Text InteractionText;
    public Text fuelText;
    public Text energyText;
    public Text antenaText;
    private float secondTimer;
    private float debreeTimer;
    public float armorTimer;
    public int tick;

    public GameObject winMenu;
    public GameObject DeathMenu;
    public GameObject capsule;
    public GameObject capsulePrefab;
    public GameObject barikad;
    public GameObject baricadeSpawnPoint;
    public GameObject MenuCanvas;
    public bool cpsuleInHands = false;
    public Text winText;
    public Text deathText;

    public int wiresCount;
    public int micCount;
    public int metalCount;
    public int batteryCharge;
    public int maxBattaryCharge;
    public int antenaCharge;
    public bool engineWork = true;

    public int fuel = 20;
    public GameObject debree;
    public GameObject ResqueShip;
    private bool ShipInProgress = false;
    private int resqued = 0;
    public bool menu = false;



    void Awake()
    {
        Time.timeScale = 0f;
        gameEngine = this.GetComponent<GameEngine>();
        batteryCharge = maxBattaryCharge;
    }
    public void GameStart()
    {
        Time.timeScale = 1f;
      
    }

    public void Win()
    {
        winMenu.SetActive(true);

        winText.text = "People who still alive by you action =" + resqued;
        Time.timeScale = 0f;
        engineWork = false;

    }

    public void Death(int scenario)
    {
        DeathMenu.SetActive(true);
        if (scenario == 1)
        {
            deathText.text = "You lost in space";
        }

        Time.timeScale = 0f;
        engineWork = false;
    }

    private void FixedUpdate()
    {
        debreeTimer += Time.deltaTime;
        secondTimer += Time.deltaTime;
        armorTimer += Time.unscaledDeltaTime;

    }

    public void MenuCall()
    {
        if ((DeathMenu.active == false) && (winMenu.active == false))
        {
            
          
            if (MenuCanvas.active==true)
            {
                MenuCanvas.SetActive(false);
                Time.timeScale = 1f;
              //  engineWork = true;
                armorTimer = 0;


            }
            else
            {
                
                {
                    MenuCanvas.SetActive(true);
                    Time.timeScale = 0f;

                  //  engineWork = true;
                }
              
            
            }
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(0);
        engineWork = true;
    }
    public void LunchResqueShip()
    {
        Vector3 randomPoint = Random.onUnitSphere * 150;
        randomPoint = new Vector3(randomPoint.x, 0f, randomPoint.z);
        GameObject ship = Instantiate(ResqueShip, (randomPoint), Quaternion.identity);
        ship.transform.LookAt(new Vector3(0f, 0f, 0f));
    }



    // Update is called once per frame
    void Update()
    {
     
        if (secondTimer > 1)
        {
            tick++;
            secondTimer = 0;

            //  SpawnADebree();

        }
        if (debreeTimer > 3)
        {
            //  tick++;
            debreeTimer = 0;

            SpawnADebree();

        }


        if ((antenaCharge > 60) && (!ShipInProgress))
        {
            LunchResqueShip();
            ShipInProgress = true;
        }
        if (Input.GetKey(KeyCode.Q) && (cpsuleInHands))
        {

            DropCapsule();
        }
        if (Input.GetKey(KeyCode.F) && (armorTimer > 1))
        {
            armorTimer = 0;
            SpawnBarikade();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            
            
               
                MenuCall();
            
        
        }
            


        metalText.text = "Metal=" + metalCount.ToString();
        wiresText.text = "Wires=" + wiresCount.ToString();
        micText.text = "Microschemes=" + micCount.ToString();
        fuelText.text = "fuel=" + fuel.ToString();
        energyText.text = "battery=" + batteryCharge.ToString() + "/" + maxBattaryCharge;
        if (antenaCharge <= 120)
        {
            antenaText.text = "antena=" + antenaCharge.ToString() + "/60";
        }
        else
        {
            antenaText.text = "Emegensy teperoter platform varped close to station";
        }
    }

    public void SpawnBarikade()
    {

        if ((metalCount > 0) && (wiresCount > 0) && (micCount > 0))
        {
            metalCount--;
            wiresCount--;
            micCount--;
            GameObject barikade = Instantiate(barikad, baricadeSpawnPoint.transform.position, baricadeSpawnPoint.transform.rotation);
        }



    }

    Vector3 randomCircleCoordinate(float radious)
    {

        return Random.insideUnitCircle * radious;
    }

    void SpawnADebree()
    {

        Vector3 randomPoint = Random.onUnitSphere * 200;
        randomPoint = new Vector3(randomPoint.x, 0f, randomPoint.z);

        //  Debug.Log(randomPoint);
        GameObject ball = Instantiate(debree, (randomPoint), Quaternion.identity);
        ball.transform.LookAt(new Vector3(0f, 0f, 0f));

    }

    public void ChangeCharge(int charge)
    {
        batteryCharge += charge;
        if (batteryCharge < 0)
        {
            batteryCharge = 0;
        }

        if (batteryCharge > maxBattaryCharge)
        {
            batteryCharge = maxBattaryCharge;
        }
    }

    public void PickUPCapsule()
    {

        capsule.SetActive(true);
        cpsuleInHands = true;

    }

    public void DropCapsule()
    {

        capsule.SetActive(false);
        cpsuleInHands = false;

        GameObject CapsuleToDrop = Instantiate(capsulePrefab, capsule.transform.position, Quaternion.identity);
        CapsuleToDrop.SetActive(true);
        // ship.transform.LookAt(new Vector3(0f, 0f, 0f));

    }
    public void TeleportCapsule()
    {
        capsule.SetActive(false);
        cpsuleInHands = false;


        resqued++;
    }
}
