using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatedObjectScript : MonoBehaviour
{
    Transform sunTransform;
    [SerializeField] public float distanceFromTheSun = 50f;
    [SerializeField] float movementSpeed = 10f;
    void Start()
    {
        sunTransform = GameObject.Find("Sun").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(sunTransform.position, transform.position);
        if (distance > distanceFromTheSun)
        {
            float movement = movementSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, sunTransform.position, movement);
        }
        else
        {
            transform.SetParent(sunTransform);
        }
    }
}
