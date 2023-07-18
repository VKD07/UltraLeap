using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPickup : MonoBehaviour
{
    [SerializeField] Transform rayOrigin;
    [SerializeField] Transform ballPlacement;
    [SerializeField] float rayDistance;
    [SerializeField] LayerMask layer;
    [SerializeField] bool handGrasp;
    [SerializeField] GameObject ball;
    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        DetectBall();
        GrabBall();
    }

    private void DetectBall()
    {
        Ray ray = new Ray(rayOrigin.position, -rayOrigin.up);
        if (Physics.Raycast(ray, out hit, rayDistance, layer))
        {
            if (hit.collider != null)
            {
                ball = hit.collider.gameObject;
            }
        }
    }

    private void GrabBall()
    {
        if (ball != null && handGrasp)
        {
            ball.transform.position = hit.point;
        }
        else
        {
            ball = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(rayOrigin.position, -rayOrigin.up * rayDistance);
    }

    public void Pinch()
    {
        print("Pinched");
    }

    public bool BallOnhand
    {
        get { return handGrasp; }
        set { handGrasp = value; }
    }
}
