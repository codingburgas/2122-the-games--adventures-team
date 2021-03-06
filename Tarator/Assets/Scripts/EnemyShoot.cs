using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float speed;
    public int damage;
    private Transform player;
    private Vector2 target;
    private int lifespan =  1500;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        target = new Vector2(player.position.x, player.position.y);
    }    

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }

        lifespan -= 1;

        if(lifespan <= 0)
        {
            DestroyProjectile();
            lifespan = 1500;
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
            DestroyProjectile();
        }
        
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }    
}
