using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashAttack : MonoBehaviour
{
    public CircleCollider2D collider;
    public float damage = 10;


    private void Start() 
    {
        collider.enabled = false;
    }

    public void Splash()
    {
        collider.enabled = true;        
    }

    public void StopSplash()
    {
        collider.enabled = false;
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
            }
        }
        if(other.tag == "TankGhost")
        {
            TankEnemy TankEnemy = other.GetComponent<TankEnemy>();

            if(TankEnemy != null)
            {
                Debug.Log("HIT");
                TankEnemy.Health -= damage;
            }
        }
        if(other.tag == "ShooterGhost")
        {
            ShooterEnemy ShooterEnemy = other.GetComponent<ShooterEnemy>();

            if(ShooterEnemy != null)
            {
                Debug.Log("HIT");
                ShooterEnemy.Health -= damage;
            }
        }
    }
}
