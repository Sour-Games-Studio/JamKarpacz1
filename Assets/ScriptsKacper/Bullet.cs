using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] public string owner = "Player";
    [SerializeField] public float damage = 1f;
    
    private void OnTriggerEnter(Collider other)
    {
        //print tag it entered
        //Debug.Log(other.tag+ "Entered tag");
        if (other.CompareTag("Player")&& owner == "Enemy")
        {
            other.GetComponent<PlayerMovement>().TakeDamagePlayer(damage);
            
        }
        if (other.CompareTag("Enemy") && owner == "Player")
        {
            other.GetComponent<EnemyAi>().TakeDamage(damage);
        }
        if (other.tag == owner)
        {
            return;
        }
        Destroy(this.gameObject);
       
    }
}
