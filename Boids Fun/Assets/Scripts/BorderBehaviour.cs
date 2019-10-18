using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderBehaviour : MonoBehaviour
{

    private const float BUFFOR_VALUE_AFTER_MOVING = 1.0f;
    [HideInInspector] public static float verExtent;
    [HideInInspector] public static float horExtent;
    private BoxCollider boxCollider;

    private void Awake()
    {
        verExtent = Camera.main.orthographicSize;
        horExtent = (verExtent * Screen.width / Screen.height);

        boxCollider = GetComponent<BoxCollider>();
        boxCollider.size = new Vector3(horExtent * 2, verExtent * 2, 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.name}");   
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        Debug.Log($"{other.name} has left border");
        Vector3 targetPosition = other.transform.position;

        targetPosition = -other.transform.position;
        /*
        if (other.transform.position.x >= horExtent || other.transform.position.x <= -horExtent)
        {
            targetPosition.x = -other.transform.position.x;

            if (targetPosition.x > 0)
                targetPosition.x -= BUFFOR_VALUE_AFTER_MOVING;
            else if (targetPosition.x < 0)
                targetPosition.x += BUFFOR_VALUE_AFTER_MOVING;
        }

        if (other.transform.position.z >= verExtent || other.transform.position.z <= -verExtent)
        {
            targetPosition.z = -other.transform.position.z;

            if (targetPosition.z > 0)
                targetPosition.z -= BUFFOR_VALUE_AFTER_MOVING;
            else if (targetPosition.z < 0)
                targetPosition.z += BUFFOR_VALUE_AFTER_MOVING;
        }
        */

        other.transform.position = targetPosition;
    }
}