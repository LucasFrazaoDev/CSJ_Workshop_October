using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    public float fallingTime;

    private BoxCollider2D boxCollider;
    private TargetJoint2D joint;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        joint = GetComponent<TargetJoint2D>();
    }

    private void FallPlataform()
    {
        boxCollider.enabled = false;
        joint.enabled = false;
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.transform.CompareTag("Player"))
        {
            Invoke("FallPlataform", fallingTime);
        }
    }
}
