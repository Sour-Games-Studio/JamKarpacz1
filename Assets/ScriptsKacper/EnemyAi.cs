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
            currentBullet.transform.position = this.transform.position;
           currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
            attackSpeedTimer = attackSpeed;          
        }
        Debug.Log(attackSpeedTimer.ToString());
    }

    
   
}
