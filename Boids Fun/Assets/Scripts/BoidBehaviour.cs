using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidBehaviour : MonoBehaviour
{
    private Vector3 currentVelocity = Vector3.zero;
    public Vector3 CurrentVelocity
    {
        get => currentVelocity;
        set
        {
            currentVelocity = value.magnitude < maxVelocity ? value : value.normalized * maxVelocity;

            //Math.Atan2(vector2.Y, vector2.X) - Math.Atan2(vector1.Y, vector1.X);
            float angle = Mathf.Atan2(currentVelocity.y, currentVelocity.x) * Mathf.Rad2Deg - 90;

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, angle), 5);
        }
    } 
    public const float maxVelocity = 0.75f; 
}
