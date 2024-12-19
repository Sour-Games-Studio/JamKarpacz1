using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bullet2;
    [SerializeField] private float attackSpeedTimer;
    [SerializeField] private float attackSpeed = 3f;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float damage;
    
    [SerializeField] private float hp = 3;
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
        //Debug.Log("Enemy took "+damage+" damage");
        if (hp<1)
        {
            Destroy(this.gameObject);
        }
    }
   
}
