using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RangedAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float attackRange = 0.1f;
    [SerializeField] public float attackDamage = 1f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRate = 2f;
    private float nextAttackTime = 0f;

    [SerializeField] public float bulletSpeed = 100f;

    public int ammoMax = 3;
    public int ammoCurrent = 3;

    public GameObject bullet;

    [SerializeField] private TMP_Text AmmoText;

    private void Start()
    {
        UpdateAmmoText();
    }

    public void TryAttack(float angle)
    {
        Debug.Log("ammoCurrent: " + ammoCurrent);
        if (Time.time >= nextAttackTime && ammoCurrent!=0)
        {
            Attack(angle);
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Attack(float attackDirection)
    {
        ammoCurrent--;
        UpdateAmmoText();
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

    public void UpdateAmmoText()
    {
        AmmoText.text = "X " + ammoCurrent;
    }

    // Update is called once per frame
}
