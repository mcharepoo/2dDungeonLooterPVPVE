using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UseEscapePortalScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float distanceCanLootFrom = 2;

    [SerializeField] GameObject useEscapePortalText;

    [SerializeField] Animator animator;

    [SerializeField] float animationWaitTime;
    [SerializeField] GameObject youHaveEscapedText;

    public bool portalUsed = false;

    [SerializeField] SpriteRenderer portalSpriteRenderer;
    [SerializeField] UsedEscapePortalScript usedEscapePortalScript;
    [SerializeField] PlayerInventoryScript playerInventoryScript;
    public CarryInventoryFromGameToMainMenu carryInventoryFromGame;
    
   
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerInventoryScript = player.gameObject.GetComponent<PlayerInventoryScript>(); 
        portalSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        usedEscapePortalScript = player.gameObject.GetComponent<UsedEscapePortalScript>();
        carryInventoryFromGame = GameObject.FindGameObjectWithTag("Inventory").GetComponent<CarryInventoryFromGameToMainMenu>();
    }

    // Update is called once per frame
    void checkDistance()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(player.position, transform.position);
            if (distance < distanceCanLootFrom && !portalUsed)
            {
                useEscapePortalText.SetActive(true);
                
            }   // You can now use the 'distance' variable in your game logic.
            else
            {
                useEscapePortalText.SetActive(false);

            }
        }
    }

    void UseEscapePortal()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        if(distance < distanceCanLootFrom && Input.GetKeyUp(KeyCode.F) && !portalUsed)
        {
            StartCoroutine(animationWait());
        }
    }

    IEnumerator animationWait()
    {
        portalUsed = true;
        animator.SetBool("Despawn", true);
        yield return new WaitForSeconds(animationWaitTime);
       
        portalSpriteRenderer.enabled = false;
        usedEscapePortalScript.disableAllPlayerSprites();
        youHaveEscapedText.SetActive(true);
        yield return new WaitForSeconds(4);
        youHaveEscapedText.SetActive(false) ;
        
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(0);

        // Optionally, you can disable the current scene's GameObjects during the loading process
        // For example, if you want to show a loading screen or loading progress bar.


        // Wait for the new scene to finish loading
        while (!asyncOperation.isDone)
        {
            // You can display a loading progress bar here by using asyncOperation.progress
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100) + "%");

            yield return null;
        }

        // The new scene is now loaded and active
        // Re-enable any GameObjects you may have disabled earlier
        // EnableAllGameObjectsInNewScene();

        Debug.Log("Scene " + "MainMenu" + " loaded");
    }

    private void Update()
    {
        checkDistance();
        UseEscapePortal();
    }


}
