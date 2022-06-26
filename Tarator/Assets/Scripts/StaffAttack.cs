using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffAttack : MonoBehaviour
{
    public float damage = 20;

    Vector2 attackOffset;
    public Collider2D staffCollider;

    private void Start() 
    {
        attackOffset = transform.position;
    }

    public void AttackRight()
    {
        Debug.Log("Right");
        staffCollider.enabled = true;
        transform.localPosition = attackOffset;
    }

    public void AttackLeft()
    {
        Debug.Log("Left");
        staffCollider.enabled = true;
        transform.localPosition = new Vector3(attackOffset.x * -1, attackOffset.y);
    }

    public void StopAttack()
    {
        staffCollider.enabled = false;
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
    }
}
