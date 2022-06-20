using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFollow : MonoBehaviour
{
   //Object you want to follow
    public Transform target;
    
    //Set to z -10
    public Vector3 offset;
    
    //How much delay on the follow
    [Range(1, 10)]
    public float smoothing;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
