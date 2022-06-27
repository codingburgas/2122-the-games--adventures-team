using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    public float Health {
        set {
            health = value;

            if(health <= 0)
            {
                Defeated();
            }
        }
        get {
            return health;
        }
    }

    public float health = 200;
    public int damage = 3;
    public float speed;
    public float StoppintDistance;

    private Transform target;


    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update(){
        
        if(Vector2.Distance(transform.position, target.position) > StoppintDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (Health <= 0)
        {
            Defeated();
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        { 
            PlayerController player = other.GetComponent<PlayerController>();

            if(player != null)
            {
                Debug.Log("HIT");
                player.Health -= damage;
            }
        }
    }

    public void Defeated()
    {
        Destroy(gameObject);
    }
}
