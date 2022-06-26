using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : MonoBehaviour
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

    public float health = 100;
    public int damage = 7;
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

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    public void Defeated()
    {
        Debug.Log("DED");
        Destroy(gameObject);
    }
}
