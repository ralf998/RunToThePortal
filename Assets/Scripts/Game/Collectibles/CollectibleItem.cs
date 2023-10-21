using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CollectibleItem : MonoBehaviour
{

    public TextMeshProUGUI info;

    private GameController gameController;
    private GameObject player;
    private ItemCompendium compendium;

    public int randomID;

    public int itemID;
    public string itemName = "Test";
    public string itemDescription = "Testing bro";
    public bool collected = false;

    
    public ItemCompendium.ItemData currentItem;

    private bool isButtonDown;
    private float bTimer;

    // Start is called before the first frame update

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collected = true;
            player = collision.gameObject;
        }
    }
    void Start()
    {
        compendium = ItemCompendium.Instance;
        gameController = GameController.Instance;





        //Debug.Log(ItemCompendium.Instance.testeCoisa);

    }

     void Update()
    {        
        if (collected == true)
        {
            player.GetComponent<PlayerController>().collectItem(gameObject);
        }
    }

    
    // Update is called once per frame




}
