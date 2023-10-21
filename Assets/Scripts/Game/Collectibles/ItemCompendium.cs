using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemCompendium : MonoBehaviour
{
    public static ItemCompendium Instance { get; private set; }
    public List<ItemCompendium.ItemData> itemGlossary;
    public List<Sprite> sprites;

    public struct ItemData
    {
        public int ID;
        public string Name;
        public string Description;
        public ItemData(string name, int id, string description)
        {
            ID = id;
            Name = name;
            Description = description;
        }        
        public bool isNull()
        {
            return ID == -1;
        }
    }

    void Awake()
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
    }

    // Start is called before the first frame update
    void Start()
    {        
        ItemData item1 = new ItemData("Speed Cola", 0, "Increases the move speed of your character");
        ItemData item2 = new ItemData("Health Elixir", 1, "Cures wounds");
        ItemData item3 = new ItemData("Suvivor's Skillbook", 2, "Increases max health");
        ItemData item4 = new ItemData("Elixir of Hardening", 3, "Increases player resistance to damage");                
        ItemData item5 = new ItemData("Animated Shield", 4, "spawns a shield around you that moves around and nullifies one damage");
        ItemData item6 = new ItemData("Ilusionist Cola", 5, "Makes the player invisible for 1 minute");
        ItemData item7 = new ItemData("Unbreakable Cola", 6, "Increases the player damage resistance by 50% for 2 minutes");
        itemGlossary = new List<ItemData> { item1, item2, item3, item4, item5, item6, item7 };
    }

    // Update is called once per frame
    void Update()
    {

    }
}
