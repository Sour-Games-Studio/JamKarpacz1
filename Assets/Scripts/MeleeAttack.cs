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
        Debug.Log(attackDirection + "attackDirection");
        Vector3 attackDirectionVector = new Vector3(Mathf.Cos(attackDirection * Mathf.Deg2Rad), 0, Mathf.Sin(attackDirection * Mathf.Deg2Rad));
        Debug.Log(attackDirectionVector + "attackDirectionVector");
        Vector3 attackPosition = attackPoint.position + attackDirectionVector * attackRange;
        Debug.Log(attackPosition + "attackPosition");
        Collider[] hitEnemies = Physics.OverlapSphere(attackPosition + new Vector3(1.0f,0,0), attackRange, enemyLayer);

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
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position + new Vector3(1.0f, 0, 0), attackRange);
    }
}