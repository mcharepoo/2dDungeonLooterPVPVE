using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootingChestScript : MonoBehaviour
{
    [SerializeField] Sprite openedNotLootedChest;
    [SerializeField] Sprite LootedChest;


    [SerializeField] bool chestOpened = false;
    [SerializeField] bool chestLooted = false;
    [SerializeField] bool canLoot = false;

    [SerializeField] SpriteRenderer currentSprite;

    [SerializeField] Transform player;
    [SerializeField] float distanceCanLootFrom;

    [SerializeField] LootImagesScript lootImagesScript;
    [SerializeField] PlayerInventoryScript playerInventoryScript;
 
    void Start()
    {
        currentSprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerInventoryScript = player.GetComponent<PlayerInventoryScript>();
    }
    void Update()
    {
        OpenChest();
        checkDistance();
    }

    void checkDistance()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(player.position, transform.position);
            if(distance < distanceCanLootFrom)
            {
                canLoot = true;
            }   // You can now use the 'distance' variable in your game logic.
            else
            {
                canLoot = false;
            }
        }
    }

    void OpenChest()
    {
        if(Input.GetKeyUp(KeyCode.F) && !chestOpened && !chestLooted && canLoot)
        {
            currentSprite.sprite = openedNotLootedChest;
            chestOpened = true;
        }
        else if(Input.GetKeyUp(KeyCode.F) && chestOpened && !chestLooted && canLoot)
        {
            LootGold();
            currentSprite.sprite = LootedChest;
            chestLooted = true;
        }
        else if (chestLooted)
        {
            currentSprite.sprite = LootedChest;
        }
    }

    void LootGold()
    {
        playerInventoryScript.transferItemToNextAvailableSlot(lootImagesScript.goldImage);
    }
}
