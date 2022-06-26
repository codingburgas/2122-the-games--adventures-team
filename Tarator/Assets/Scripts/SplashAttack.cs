using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashAttack : MonoBehaviour
{
    public CircleCollider2D area;

    void Start()
    {
        area = GetComponent<CircleCollider2D>();
        area.enabled = false;
    }
    
}
