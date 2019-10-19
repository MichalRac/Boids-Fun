using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    [SerializeField] private BoidBehaviour boidPrefab;
    [SerializeField] private float perciveDistance = 5f;
    private List<BoidBehaviour> boidList = new List<BoidBehaviour>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateBoid();
        }

        foreach(var boid in boidList)
        {
            MoveToNewPosition(boid);
        }
    }

    // Creates boid and adds to list
    private void CreateBoid()
    {
        for (int i = 0; i < 5; i++)
        {
            var newBoid = Instantiate(boidPrefab, transform);
            newBoid.transform.position = new Vector3(Random.Range(-30f, 30f), Random.Range(-30f, 30f));
            boidList.Add(newBoid);
        }
    }

    private void MoveToNewPosition(BoidBehaviour boid)
    {
        Vector3 component1, component2, component3;

        //component1 = Rule1.FindPointTowardsGlobalMassCentre(boidList, boid);
        component1 = Rule1.FindPointTowardsLocalMassCentre(boidList, boid, perciveDistance);
        component2 = Rule2.MoveAwayFromNearbyObjects(boidList, boid);
        component3 = Rule3.MatchVelocityOfPercivedBoids(boidList, boid, perciveDistance);

        boid.CurrentVelocity = boid.CurrentVelocity + component1 + component2 + component3;
        boid.transform.position = boid.transform.position + boid.CurrentVelocity;
    }
}
