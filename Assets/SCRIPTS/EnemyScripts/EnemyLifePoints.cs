using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyLifePoints : MonoBehaviour
{
    [SerializeField] int HealthPoints;
    [SerializeField] bool isDead;

    [SerializeField] Animator animator;

    [SerializeField] float animationWaitTime;

    [SerializeField] EnemyAggroToPlayer enemyAggroToPlayer;

    [SerializeField] Sprite deathSprite;
    [SerializeField] SpriteRenderer spriteRenderer;

    
    [SerializeField] BoxCollider2D boxCollider;
    public void TakeDamage(int damage)
    {
        HealthPoints -= damage;
        if(HealthPoints <= 0 )
        {
            isDead = true;
            enemyAggroToPlayer.canCheckDistance = false;
            boxCollider.enabled = false;
            
            StartCoroutine(deathAnimation());
        }
    }

    IEnumerator deathAnimation()
    {
        enemyAggroToPlayer.canCheckDistance = false;
        animator.SetBool("Hit", false);
        animator.SetBool("Dead", isDead);
        yield return new WaitForSeconds(animationWaitTime);
        
        animator.enabled = false;
        spriteRenderer.sprite = deathSprite;
    }


}
