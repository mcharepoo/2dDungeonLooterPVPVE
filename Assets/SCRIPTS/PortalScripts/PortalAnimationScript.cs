using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PortalAnimationScript : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float animationWaitTime;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        textMeshProUGUI = GameObject.FindGameObjectWithTag("Killfeed").GetComponent<TextMeshProUGUI>();
        StartCoroutine(waitForSpawnAnimationToBeDone());

        StartCoroutine(portalSpawnedKillFeed());
    }
    IEnumerator waitForSpawnAnimationToBeDone()
    {
        yield return new WaitForSeconds(animationWaitTime);
        animator.SetBool("Spawned", true);
    }
    IEnumerator waitForDespawnAnimationToBeDone()
    {
        yield return new WaitForSeconds(animationWaitTime);
        animator.SetBool("Spawned", true);
    }

    IEnumerator portalSpawnedKillFeed()
    {
        textMeshProUGUI.text = "1 Escape Portal Has Spawned!";
        yield return new WaitForSeconds(3);
        textMeshProUGUI.text = "";
    }
}
