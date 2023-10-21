using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CollectibleItem : MonoBehaviour
{

    public TextMeshProUGUI info;
    
    private GameObject player;
    private ItemCompendium compendium;

    public int randomID;

    public int itemID;
    public string itemName;
    public string itemDescription;
    public bool collected = false;

    
    public ItemCompendium.ItemData currentItem;

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
       
        randomID = Random.Range(0, compendium.itemGlossary.Count);

        itemName = ItemCompendium.Instance.itemGlossary[randomID].Name;
        ItemCompendium.ItemData currentItem = new(ItemCompendium.Instance.itemGlossary[randomID].Name, ItemCompendium.Instance.itemGlossary[randomID].ID, ItemCompendium.Instance.itemGlossary[randomID].Description);

        itemName = currentItem.Name;
        itemDescription = currentItem.Description;
        itemID = currentItem.ID;
        gameObject.GetComponent<SpriteRenderer>().sprite = compendium.sprites[randomID];
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
