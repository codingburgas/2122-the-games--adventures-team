using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffAttack : MonoBehaviour
{
    Vector2 attackOffset;
    Collider2D staffCollider;

    private void Start() 
    {
        staffCollider = GetComponent<Collider2D>();
        attackOffset = transform.position;
    }

    public void AttackRight()
    {
        Debug.Log("Right");
        staffCollider.enabled = true;
        transform.position = attackOffset;
    }

    public void AttackLeft()
    {
         Debug.Log("Left");
        staffCollider.enabled = true;
        transform.position = new Vector3(attackOffset.x * -1, attackOffset.y);
    }

    public void StopAttack()
    {
        staffCollider.enabled = false;
    }
}
