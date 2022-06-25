using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    Vector3 dest;
    public float speed;

    void Start()
    {
        dest = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }    

    void Update()
    {
        transform.Translate(dest.normalized * speed * Time.deltaTime);
    }
}
