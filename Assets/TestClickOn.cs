using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestClickOn : MonoBehaviour
{
    [SerializeField] int gameObjectNumber;
    [SerializeField] Sprite clickedOnSprite;

    [SerializeField] List<GameObject> inventoryLootSprites;
    [SerializeField] List<GameObject> stashLootSprites;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                // A click has been detected on a 2D sprite GameObject.
                // You can add your custom logic here.
                Debug.Log("Clicked on: " + hit.collider.gameObject.name);
                gameObjectNumber = int.Parse(hit.collider.gameObject.name);
                RightClickInventoryTransferToStash();
            }
        }
    }

    void RightClickInventoryTransferToStash()
    {
        clickedOnSprite = inventoryLootSprites[gameObjectNumber].GetComponent<Image>().sprite;
        stashLootSprites[gameObjectNumber].GetComponent<Image>().sprite = clickedOnSprite;
    }
}
