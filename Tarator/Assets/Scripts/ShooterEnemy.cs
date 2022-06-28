using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    public float Health {
        set {
            health = value;

            if(health <= 0)
            {
                //ani.Play("Shooter");
                Defeated();
            }
        }
        get {
            return health;
        }
    }

    public float health = 50;


    public float speed;
    public float stoppintDistance;
    public float retreatDistance;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public GameObject projectile;
    private Transform target;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        timeBetweenShots = startTimeBetweenShots;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > stoppintDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, target.position) < stoppintDistance && Vector2.Distance(transform.position, target.position) > retreatDistance) 
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, target.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }

        if(timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }

        if(Health <= 0)
        {
            Defeated();
        }
}

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    public void Defeated()
    {
        Destroy(gameObject);
    }
}
