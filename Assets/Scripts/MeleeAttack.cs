using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private float attackRange = 2f;
    public float attackDamage = 10f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRate = 2f;
    private float nextAttackTime = 0f;
    [SerializeField] private  GameObject attackSpherePrefab;

    public void TryAttack(float angle)
    {
        if (Time.time >= nextAttackTime)
        {
            Attack(angle);
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Attack(float attackDirection)
    {
        // Detect enemies in range of attack
        //Debug.Log(attackDirection + "attackDirection");
        Vector3 attackDirectionVector = new Vector3(Mathf.Cos(attackDirection * Mathf.Deg2Rad), 0, Mathf.Sin(attackDirection * Mathf.Deg2Rad));
        //Debug.Log(attackDirectionVector + "attackDirectionVector");
        Vector3 attackPosition = attackPoint.position + attackDirectionVector * attackRange;
        //Debug.Log(attackPosition + "attackPosition");
        //Detect enemies in range of the attack
        Collider[] hitEnemies = Physics.OverlapSphere(attackPosition, attackRange, enemyLayer);
        //print whole collider 
        // foreach (Collider enemy in hitEnemies)
        // {
        //     Debug.Log(enemy + "enemy" + enemy.tag);
        // }
        //Debug.Log(hitEnemies.Length + "hitEnemies");
        // Play an attack animation
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyAi>().TakeDamage(attackDamage);
        }

        // Spawn a sphere at the attack point to visualize the attack
        Instantiate(attackSpherePrefab, attackPosition, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        // Draw the attack range
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}