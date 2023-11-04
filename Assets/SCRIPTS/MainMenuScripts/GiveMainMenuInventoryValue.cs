using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GiveMainMenuInventoryValue : MonoBehaviour
{
    [SerializeField] List<GameObject> stashGameObjects;

    [SerializeField] List<GameObject> lootFromDungeon;

    [SerializeField] GameObject playerGameobject;
    [SerializeField] PlayerInventoryScript playerInventoryScript;
    
    [SerializeField] bool isStashOn = false;

    public GameObject mainMenuStashObj;

    [SerializeField] int stashCount;
    [SerializeField] int lootCount;

    public void toggleStash()
    {
        if (!isStashOn)
        {
            isStashOn=true;
            mainMenuStashObj.SetActive(isStashOn);
        }
        else if(isStashOn) 
        {
            isStashOn= false;
            mainMenuStashObj.SetActive(isStashOn);
        }
    }
    private void Start()
    {
        playerGameobject = GameObject.FindGameObjectWithTag("Player");
        lootFromDungeon = playerGameobject.GetComponent<PlayerInventoryScript>().inventorySlotsGameObjects;
        playerInventoryScript = playerGameobject.GetComponent<PlayerInventoryScript>();
        transferDungeonLootToMainMenuStashInvTest();
        stashCount = stashGameObjects.Count;
        lootCount = lootFromDungeon.Count;
        
        mainMenuStashObj.SetActive(false);
        
    }

    private void transferDungeonLootToMainMenuStashInv()
    {
        int objNumber = 0;
        if (objNumber <= lootFromDungeon.Count)
        {
           foreach (GameObject gameObject in lootFromDungeon)
            {

                

                stashGameObjects[objNumber].GetComponent<IsInventorySlotTakenScript>().transferItemToSlot(gameObject.GetComponent<Image>().sprite);
                stashGameObjects[objNumber].GetComponent<IsInventorySlotTakenScript>().changeAlphaColor();
                objNumber++; 
            }
        }
        else
        {
            Debug.Log("index too high");
        }
    }

    private void transferDungeonLootToMainMenuStashInvTest()
    {
        int objNumber = 0;
        
        foreach (GameObject gameObject in lootFromDungeon)
        {

            if (objNumber <= (playerInventoryScript.numberOfItemsInInventory - 1))
            {
                stashGameObjects[objNumber].GetComponent<IsInventorySlotTakenScript>().transferItemToSlot(gameObject.GetComponent<Image>().sprite);
                stashGameObjects[objNumber].GetComponent<IsInventorySlotTakenScript>().changeAlphaColor();
                objNumber++;
            }
        }
        
        
    }


    private void TransferItems()
    {
        if (lootFromDungeon.Count == stashGameObjects.Count)
        {
            for (int i = 0; i < lootFromDungeon.Count; i++)
            {
                if (lootFromDungeon[i] != null && stashGameObjects[i] != null)
                {
                    // Get the SpriteRenderer component of the source GameObject

                    Sprite objSprite = gameObject.gameObject.GetComponent<Image>().sprite;

                    if (objSprite != null)
                    {
                        // Assign the new sprite from spriteList
                        stashGameObjects[i].GetComponent<Image>().sprite = objSprite;
                    }
                    else
                    {
                        Debug.LogWarning("SpriteRenderer component missing on GameObject at index " + i);
                    }
                }
                else
                {
                    Debug.LogWarning("One or more GameObjects or sprites are missing at index " + i);
                }
            }
        }
        else
        {
            Debug.LogError("Source and sprite lists must have the same number of elements.");
        }
    }

 }
