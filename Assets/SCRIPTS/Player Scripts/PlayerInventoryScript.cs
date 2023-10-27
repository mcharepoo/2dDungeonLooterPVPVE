using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryScript : MonoBehaviour
{
    [SerializeField] GameObject inventoryUI;
    [SerializeField] bool inventoryActive = false;

    [SerializeField] List<GameObject> inventorySlotsGameObjects;

    

    void Start()
    {
        inventoryUI.SetActive(false);
    }

    void Update()
    {
        ToggleInventory();
    }

    void ToggleInventory()
    {
        if(Input.GetKeyUp(KeyCode.Tab))
        {
            if (!inventoryActive)
            {
                inventoryUI.SetActive(true);
                inventoryActive = true;
            }
            else if (inventoryActive)
            {
                inventoryUI.SetActive(false);
                inventoryActive = false;
            }
        }
    }

    public void transferItemToNextAvailableSlot(Sprite itemSprite)
    {
        foreach (GameObject inventorySlot in inventorySlotsGameObjects)
        {
            bool isTaken = inventorySlot.GetComponent<IsInventorySlotTakenScript>().isInventorySlotTaken;
            if(!isTaken)
            {
                inventorySlot.GetComponent<Image>().sprite = itemSprite;
                inventorySlot.GetComponent<IsInventorySlotTakenScript>().isInventorySlotTaken = true;
                inventorySlot.GetComponent<IsInventorySlotTakenScript>().changeAlphaColor();
                break;
            }
        }
    }
}
