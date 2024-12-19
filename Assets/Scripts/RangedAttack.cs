using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float attackRange = 2f;
    [SerializeField] public float attackDamage = 1f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRate = 2f;
    private float nextAttackTime = 0f;

    [SerializeField] public float bulletSpeed = 10f;

    public GameObject bullet;

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
        //spawn bullet in direction of attack
        var currentBullet = Instantiate(bullet, attackPosition, Quaternion.identity);
        currentBullet.GetComponent<Bullet>().owner = "Player";
        currentBullet.GetComponent<Bullet>().damage = attackDamage;

        currentBullet.GetComponent<Rigidbody>().AddForce(attackDirectionVector * bulletSpeed);

        // Spawn a sphere at the attack point to visualize the attack
        //Instantiate(attackSpherePrefab, attackPosition, Quaternion.identity);
    }

    // Update is called once per frame
}
