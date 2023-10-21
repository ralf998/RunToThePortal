using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Security.Cryptography;

public class PlayerController : MonoBehaviour {

    // PRIVATE
    private GameController gameController;
    private CollectibleItem itemScript;
    private Animator playerMovement;
    private float vertical, horizontal;
    

    // PUBLIC
    public Rigidbody2D rigidBody;
    public GameController.PlayerData playerData;
    public float timer, resistance;

    public void damagePlayer(int damage)
    {
        playerData.health -= damage * (int)(1f - resistance);
        if(playerData.health <= 0) { gameController.gameOver = true; }
    }

    void useItem()
    {
        if (playerData.collectedItem.ID == 0) // Move Speed Buff
        {
            if (playerData.speed < playerData.maxSpeed)
                playerData.speed += 1f;
        }
        else if (playerData.collectedItem.ID == 1) // Health Potion
        {
            if (playerData.health < playerData.limitHealth - 25)
                playerData.health += 25;
            else playerData.health = playerData.limitHealth;
        }
        else if (playerData.collectedItem.ID == 2) // Max Health Buff
        {
            if(playerData.limitHealth < playerData.maxHealth)playerData.limitHealth += 25;
        }
        else if (playerData.collectedItem.ID == 3) // Resistance Buff
        {
            if (playerData.resistance < playerData.maxResistance) playerData.resistance += 0.05f;
        }
        else if (playerData.collectedItem.ID == 4) // Animated Shield
        {
            playerData.shielded = true;
        }
        else if (playerData.collectedItem.ID == 5) // Invisibility
        {
            playerData.invisible = true;
            timer = 60f;
        }
        else if (playerData.collectedItem.ID == 6) // Top Resistance
        {
            resistance = playerData.maxResistance;
            timer = 120f;
        }
    }

    public void collectItem(GameObject item)
    {
        itemScript = item.GetComponent<CollectibleItem>();
        playerData.collectedItem = itemScript.currentItem;
        Destroy(item);
    }

    void Start() {
        gameController = GameController.Instance;
        playerData = gameController.playerData.GetData();
        playerData.speed = 2f;
        playerData.invisible = false;
        playerData.shielded = false;
        resistance = playerData.resistance;
        timer = 0f;
        playerMovement = GetComponent<Animator>();
        vertical = playerMovement.GetFloat("Vertical");
        horizontal = playerMovement.GetFloat("Horizontal");
    }

    void Update() {
        if(timer > 0f) {             
            timer -= Time.deltaTime; 
            if (timer <= 0f) {
                playerData.shielded = false;
                resistance = playerData.resistance;
                playerData.invisible = false;
            }

        }
        if(Input.GetKeyDown(KeyCode.Space) && !playerData.collectedItem.isNull()) { 
            useItem();
            playerData.collectedItem = new ItemCompendium.ItemData();
        }
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigidBody.velocity = (moveInput != Vector2.zero) ? playerData.speed * (moveInput).normalized : Vector2.zero;
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    }
}