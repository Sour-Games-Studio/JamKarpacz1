using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        if (other.gameObject.CompareTag("Player"))
        {
            //obrazenia dla gracza
            Debug.Log("-10hp");
        }
    }
}
