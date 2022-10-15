using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Player"))
        {
            // Apple added and destroyed
            target.GetComponent<Player>().IncreaseScore();
            Destroy(gameObject);
        }
    }
}
