using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] public string owner = "Player";
    [SerializeField] public float damage = 1f;

    public GameObject ogur;
    
    private void OnTriggerEnter(Collider other)
    {
        //print tag it entered
        if(owner == "Player"){       
            Debug.Log(other.tag+ "Entered tag" + other.name);
        }
        if (other.CompareTag("Player")&& owner == "Enemy")
        {
            other.GetComponent<PlayerMovement>().TakeDamagePlayer(damage);
            
        }
        else if (other.CompareTag("Enemy") && owner == "Player")
        {
            other.GetComponent<EnemyAi>().ammoStuck++;
            other.GetComponent<EnemyAi>().TakeDamage(damage);
            
        }
        else if (owner == "Player" && other.CompareTag("Untagged"))
        {
            Instantiate(ogur, this.transform.position+ new Vector3(0,0.2f,0), Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("lvl1"))
        {
            return;
        }

        if (other.tag == owner)
        {
            return;
        }

        Destroy(this.gameObject);
        
       
    }
}
