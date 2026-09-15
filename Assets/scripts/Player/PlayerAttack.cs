using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public float attackRadius = 5f;
    public float damage = 40;
    [SerializeField] float attackInterval = 1f;

    bool isAttacking = false;
    bool stopAttack = false;

    public void Attack(HPManager enemy)
    {

        if (isAttacking == false)
        {
            isAttacking = true;
            stopAttack = false;
            StartCoroutine(AttackHandler(enemy));
        }
    }

    public void StopAttack()
    {
        stopAttack = true;
        isAttacking = false;
    }

    IEnumerator AttackHandler(HPManager enemy)
    {
        while (stopAttack == false)
        {
            Debug.Log("Attack " + enemy.gameObject.name);
            enemy.TakeDamage(damage);
            yield return new WaitForSeconds(attackInterval);
        }
        yield return null;
    }



}



