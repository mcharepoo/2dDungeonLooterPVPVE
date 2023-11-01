using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGetHitScript : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] bool getHit = false;

    [SerializeField] int weaponDamage;
    [SerializeField] float animationWaitTime;

    [SerializeField] EnemyAggroToPlayer enemyAggroToPlayer;
    [SerializeField] EnemyLifePoints enemyLifePoints;


   
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other Collider2D has the desired tag
        if (other.CompareTag("PlayerWeaponHitbox") && !getHit) // Replace "YourTag" with the tag of the GameObject with the other Box Collider2D.
        {
            Debug.Log("Weapon hit");
            StartCoroutine(hitAnimation());

        }
    }

    IEnumerator hitAnimation()
    {
        getHit = true;
        enemyAggroToPlayer.canCheckDistance = false;
        animator.SetBool("Hit", getHit);
        yield return new WaitForSeconds(animationWaitTime);
        animator.SetBool("Hit", !getHit);
        
        getHit = false;
        enemyAggroToPlayer.canCheckDistance = true;
        enemyLifePoints.TakeDamage(weaponDamage);
    }
}
