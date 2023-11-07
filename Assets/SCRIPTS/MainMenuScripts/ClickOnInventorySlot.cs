using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickOnInventorySlot : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Image invSpaceImage;
    [SerializeField] Image thisGameObjImage;
    public void clickedOn()
    {
        Debug.Log("ive been clikced bitch");
    }

    private void Update()
    {
        thisGameObjImage.sprite = invSpaceImage.sprite;
    }
}
