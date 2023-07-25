using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    [SerializeField] Transform rayCastOrigin;
    [SerializeField] float rayDistance = 10f;
    [SerializeField] LayerMask layer;
    [SerializeField] GameObject objectDetected;
    RaycastHit hit;
    [SerializeField] public bool pinchRight;
    [SerializeField] public bool pinchLeft;

    [Header("Fingers")]
    [SerializeField] Transform fingerRight;
    [SerializeField] Transform  fingerLeft;
    [SerializeField] public float distance;
    // Update is called once per frame
    void Update()
    {
        DetectObject();
        //Drag();
        Resize();
    }

    private void DetectObject()
    {
        Ray ray = new Ray(rayCastOrigin.position, rayCastOrigin.right);
        if (Physics.Raycast(ray, out hit, rayDistance, layer))
        {
            objectDetected = hit.collider.gameObject;
            Debug.Log("Detected");
        }
        else
        {
            //objectDetected = null;
        }
    }

    void Drag()
    {
        if (pinchRight && objectDetected != null)
        {
            objectDetected.transform.position = hit.point;
        }
    }

    void Resize()
    {
        distance = Vector3.Distance(fingerLeft.position, fingerRight.position);

        if (pinchLeft && pinchRight && objectDetected != null)
        {
            objectDetected.transform.localScale = new Vector3(distance, distance, distance);
        }
    }

    private void OnDrawGizmos()
    {
        if (objectDetected)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.yellow;
        }
        Gizmos.DrawLine(rayCastOrigin.position, rayCastOrigin.right * rayDistance);
    }

    public void IsPinchingRight(bool value)
    {
        pinchRight = value;
    }

    public void IsPinchingLeft(bool value)
    {
        pinchLeft = value;
    }
}
