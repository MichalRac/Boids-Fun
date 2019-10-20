using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TargetPoint
{
    public static Vector3 TowardsPoint(BoidBehaviour percivingBoid, Vector3 targetPoint)
    {
        Vector3 result = (targetPoint - percivingBoid.transform.position) / 100;
        Debug.Log($"target point {targetPoint}, boid {percivingBoid.transform.position}");
        return result;
    }
}
