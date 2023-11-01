using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootGemScript : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] PlayerInventoryScript playerInventoryScript;
    [SerializeField] LootImagesScript lootImagesScript;
    [SerializeField] float distanceCanLootFrom = 1.9f;

    [SerializeField] bool canLoot = false;

    [SerializeField] GameObject lootItemText;

    
    void Start()
    {
        lootImagesScript = gameObject.GetComponent<LootImagesScript>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerInventoryScript = playerTransform.GetComponent<PlayerInventoryScript>();
        
    }


    void Update()
    {
        checkDistance();
        LootItem();
    }
    void checkDistance()
    {
        if (playerTransform != null)
        {
            float distance = Vector2.Distance(playerTransform.position, transform.position);
            if (distance < distanceCanLootFrom)
            {
                lootItemText.SetActive(true);
                canLoot = true;
            }   // You can now use the 'distance' variable in your game logic.
            else
            {
                lootItemText.SetActive(false);
                canLoot = false;

            }
        }
    }

    void LootItem()
    {
        if(Input.GetKeyUp(KeyCode.F) && canLoot)
        {
            playerInventoryScript.transferItemToNextAvailableSlot(lootImagesScript.redGemImage);
            Destroy(gameObject);
        }
    }
    
}
