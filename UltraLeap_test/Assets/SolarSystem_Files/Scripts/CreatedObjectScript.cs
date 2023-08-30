using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatedObjectScript : MonoBehaviour
{
    Transform sunTransform;
    TrailRenderer trailRenderer;
    [SerializeField] public float distanceFromTheSun = 50f;
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] public float rotationSpeed = 20f;
    void Start()
    {
        sunTransform = GameObject.Find("Sun").transform;
        trailRenderer = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveAndRotate();
    }

    private void MoveAndRotate()
    {
        float distance = Vector3.Distance(sunTransform.position, transform.position);
        if (distance > distanceFromTheSun)
        {
            float movement = movementSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, sunTransform.position, movement);
        }
        else
        {
            trailRenderer.enabled = true;
            transform.RotateAround(sunTransform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
