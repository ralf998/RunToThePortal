using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using static UnityEditor.Progress;

public class GameController : MonoBehaviour
{


    public struct PlayerData
    {
        public int health, maxHealth, limitHealth;
        public float resistance, maxResistance, speed, maxSpeed;
        public bool shielded, invisible;
        public ItemCompendium.ItemData collectedItem;
        public void StartPlayer()
        {
            health = 100;            
            limitHealth = 100;
            maxHealth = 200;
            resistance = 0f;
            maxResistance = 0.5f;
            speed = 2f;
            maxSpeed = 6f;
            shielded = false;
            invisible = false;
            collectedItem = new ItemCompendium.ItemData("null", -1, "null");
        }

        public void LoadData(PlayerData data)
        {
            this.health = data.health;
            this.maxHealth = data.maxHealth;
            this.resistance = data.resistance;
            this.maxResistance = data.maxResistance;
            this.shielded = data.shielded;
            this.speed = data.speed;
            this.maxSpeed = data.maxSpeed;
            this.invisible = data.invisible;
        }
        public PlayerData GetData() { return this; }
    }

    // Controllers
    int generator;
    SpriteRenderer aux;
    private CollectibleItem itemScript;
    public bool gameOver;


    // Final Variables    
    public static GameController Instance { get; private set; }

    private ItemCompendium compendium;
    private List<string> mapsPointer = new List<string> { "1" };

    // Changeable Variables
    private float timeLeft;
    private GameObject[] itemsSP, obstaclesSP;
    private GameObject map, newMap, newItem,newObstacle, portal;

    public PlayerData playerData;

    // Prefabs
    public GameObject item,obstacle;

    // Lists of Possible Spawn Points

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {

            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
        gameOver = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerData.StartPlayer();
        compendium = ItemCompendium.Instance;
        //loadMap();

    }

    // Update is called once per frame
    
    void generateMap(Scene scene, LoadSceneMode mode)
    {       
        //map = GameObject.FindGameObjectWithTag("Map");
        itemsSP = GameObject.FindGameObjectsWithTag("ItemSpawnPoint");     
        obstaclesSP = GameObject.FindGameObjectsWithTag("ObstacleSpawnPoint");
        portal = GameObject.FindGameObjectWithTag("Portal");
        generateItems();
        Invoke("loadLevel" + mapsPointer[generator], 0f);
        mapsPointer.Remove(mapsPointer[generator]);
        //generateObstacles();
    }

    public void loadMap()
    {
        generator = Random.Range(0, mapsPointer.Count);
        Debug.Log("Level_" + mapsPointer[generator]);
        SceneManager.LoadScene("Level_" + mapsPointer[generator]);
        
        SceneManager.sceneLoaded += generateMap;
    }
    void LoadLevel1()
    {
        timeLeft = 60f;
    }
    void generateItems()
    {
        foreach (GameObject itemSP in itemsSP)
        {
            generator = Random.Range(0, 2);
            if (generator == 1)
            {
                newItem = Instantiate(item, itemSP.transform.position, Quaternion.identity);                
            }
        }
    }
    void generateObstacles()
    {
        foreach (GameObject obstacleSP in obstaclesSP)
        {
            generator = Random.Range(0, 2);
            if (generator == 1)
            {
                newObstacle = Instantiate(obstacle, obstacleSP.transform.position, Quaternion.identity);                
            }

        }
    }
    private void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft-= Time.deltaTime;
        }
        else
        {
            portal.GetComponent<Portal>().Activate();
        }
    }

}
