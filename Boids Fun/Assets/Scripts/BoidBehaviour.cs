using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BoidType
{
    Standard = 0,
    Predator = 1
}

public class BoidBehaviour : MonoBehaviour
{
    public const float maxVelocity = 0.75f;

    private BoidType boidType;
    private Vector3 currentVelocity = Vector3.zero;

    public Vector3 CurrentVelocity
    {
        get => currentVelocity;
        set
        {
            currentVelocity = value.magnitude < maxVelocity ? value : value.normalized * maxVelocity;

            float angle = Mathf.Atan2(currentVelocity.y, currentVelocity.x) * Mathf.Rad2Deg - 90;

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, angle), 5);
        }
    }

    public BoidType BoidType { get; set; }

    public Vector3 defaultMovement()
    {
        return new Vector3(Random.Range(-maxVelocity, maxVelocity), Random.Range(-maxVelocity, maxVelocity));
    }
}
