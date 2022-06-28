using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public Transform point;
    public float timeBetweenShots;
    public float startTimeBetweenShots;
    public GameObject projectile;

    void Update()
    {
       if(timeBetweenShots <= 0)
        {
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    } 
}
