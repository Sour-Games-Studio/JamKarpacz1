using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject ogur;
    [SerializeField] private float attackSpeedTimer;
    [SerializeField] private float attackSpeed = 3f;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float damage;
    
    [SerializeField] private float hp = 3;

    public int ammoStuck = 0;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        attackSpeedTimer = attackSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;
        if (attackSpeedTimer > 0)
        {
            attackSpeedTimer -= Time.deltaTime;
        }
        else if (attackSpeedTimer <= 0)
        {
            //strzal
            var currentBullet = Instantiate(bullet);
            currentBullet.GetComponent<Bullet>().owner = "Enemy";
            currentBullet.transform.position = this.transform.position;
           currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
           
            attackSpeedTimer = attackSpeed;          
        }

        //checking if collides with player
        if (Vector3.Distance(player.transform.position, this.transform.position) < 2)
        {
            player.GetComponent<PlayerMovement>().TakeDamagePlayer(1);
        }
        //Debug.Log(attackSpeedTimer.ToString());

    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        Debug.Log("Enemy took "+damage+" damage");
        Debug.Log("Enemy hp: "+hp);
        if (hp<1)
        {
            if (ammoStuck > 0)
            {
                //spawn ammoStuck amount of ammon on the ground
                for (int i = 0; i < ammoStuck; i++)
                {
                    Instantiate(ogur, this.transform.position + new Vector3(0,2,0), Quaternion.identity);
                }
            }
            Debug.Log("Enemy died");
            player.GetComponent<PlayerMovement>().killCount++;
            Destroy(this.gameObject);
        }
    }

    public void TakeMeleeDamage(float damage)
    {
        hp -= damage;
        Debug.Log("Enemy took "+damage+" damage");
        if (hp<1)
        {
            if (ammoStuck > 0)
            {
                player.GetComponent<RangedAttack>().ammoCurrent += ammoStuck;
            }
            else if (player.GetComponent<RangedAttack>().ammoCurrent < player.GetComponent<RangedAttack>().ammoMax)
            {
                player.GetComponent<RangedAttack>().ammoCurrent++;
            }
            Destroy(this.gameObject);
        }
    }
   
}
