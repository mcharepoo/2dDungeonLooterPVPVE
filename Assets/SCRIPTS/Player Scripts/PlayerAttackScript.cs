using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float swordAttackTime;
    [SerializeField] bool isAlreadyAttacking = false;

    void Update()
    {
        BasicSwordAttack();
    }

    void BasicSwordAttack()
    {
        if (Input.GetMouseButtonDown(0) && !isAlreadyAttacking)
        {
            StartCoroutine(basicSwordAttackEnumerator());
        }
        
    }

    IEnumerator basicSwordAttackEnumerator()
    {
        isAlreadyAttacking = true;
        animator.SetBool("Attacking", true);
        yield return new WaitForSeconds(swordAttackTime);
        animator.SetBool("Attacking", false);
        isAlreadyAttacking = false;
    }
}
