using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFollow : MonoBehaviour
{
   public float speed;
    public float StoppintDistance;

    private Transform target;


    void Start() 
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > StoppintDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if(target.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(0.5f,0.5f,1);
        }
        else if(target.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-0.5f,0.5f,1);
        }  
    }
}
