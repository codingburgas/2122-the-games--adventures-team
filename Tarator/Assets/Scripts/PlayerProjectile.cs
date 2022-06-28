using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    Vector3 dest;
    public float speed;
    public float damage = 5;
    private int lifespan =  1500;

    void Start()
    {
        dest = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }    

    void Update()
    {
        transform.Translate(dest.normalized * speed * Time.fixedDeltaTime);


        lifespan -= 1;

        if(lifespan <= 0)
        {
            DestroyProjectile();
            lifespan = 1500;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "FastGhost")
        {
            FastEnemy fastEnemy = other.GetComponent<FastEnemy>();

            if(fastEnemy != null)
            {
                Debug.Log("HIT");
                fastEnemy.Health -= damage;
                DestroyProjectile();
            }
        }
        if(other.tag == "TankGhost")
        {
            TankEnemy TankEnemy = other.GetComponent<TankEnemy>();

            if(TankEnemy != null)
            {
                Debug.Log("HIT");
                TankEnemy.Health -= damage;
                DestroyProjectile();
            }
        }
        if(other.tag == "ShooterGhost")
        {
            ShooterEnemy ShooterEnemy = other.GetComponent<ShooterEnemy>();

            if(ShooterEnemy != null)
            {
                Debug.Log("HIT");
                ShooterEnemy.Health -= damage;
                DestroyProjectile();
            }
        }
        
        if(other.tag != "Player")
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
