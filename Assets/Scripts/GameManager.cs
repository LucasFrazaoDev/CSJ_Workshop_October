using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform point;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Player>().transform.position = point.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
