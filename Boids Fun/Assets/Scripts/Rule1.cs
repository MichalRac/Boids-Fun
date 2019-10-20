using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Rule1
{
    private const float DISTANCE_FACTOR = 1000;

    // SIMPLIFIED - All boids have global awareness
    public static Vector3 FindPointTowardsGlobalMassCentre(List<BoidBehaviour> boidList, BoidBehaviour percivingBoid)
    {
        Vector3 massCentre = Vector3.zero;

        foreach (var boid in boidList)
        {
            massCentre.x += boid.transform.position.x;
            massCentre.y += boid.transform.position.y;
        }

        massCentre /= boidList.Count;

        return (massCentre - percivingBoid.transform.position) / DISTANCE_FACTOR;
    }

    // DETAILED - boids have limited awarness
    public static Vector3 FindPointTowardsLocalMassCentre(List<BoidBehaviour> boidList, BoidBehaviour percivingBoid, float perciveDistance)
    {
        Vector3 massCentre = Vector3.zero;

        int percivedBoidsCount = 0;

        foreach (var boid in boidList)
        {
            if (boid == percivingBoid)
                continue;

            if (Vector3.Distance(percivingBoid.transform.position, boid.transform.position) > perciveDistance)
                continue;

            percivedBoidsCount++;
            massCentre.x += boid.transform.position.x;
            massCentre.y += boid.transform.position.y;
        }

        massCentre /= percivedBoidsCount;

        return (massCentre - percivingBoid.transform.position) / DISTANCE_FACTOR;
    }

}
