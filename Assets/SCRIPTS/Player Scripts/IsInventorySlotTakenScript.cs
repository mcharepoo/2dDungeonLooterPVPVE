using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class IsInventorySlotTakenScript : MonoBehaviour
{
    public bool isInventorySlotTaken = false;

    [SerializeField] Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void transferItemToSlot(Sprite itemSprite)
    {
        if(!isInventorySlotTaken)
        {
            isInventorySlotTaken = true;
            image.sprite = itemSprite;
            
        }
    }

    public void changeAlphaColor()
    {
        Color currentColor = image.color;
            
        currentColor.a = 250;
        image.color = currentColor;
    }
}
