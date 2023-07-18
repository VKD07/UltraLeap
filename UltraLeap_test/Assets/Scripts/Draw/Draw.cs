using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    [SerializeField] Transform point;
    [SerializeField] LayerMask layer;
    [SerializeField] float rayDistance = 5f;
    RaycastHit hit;

    private void Update()
    {
        RayCast();
    }

    private void RayCast()
    {
        Ray ray = new Ray(point.position, Vector3.forward);
        if(Physics.Raycast(ray, out hit, rayDistance, layer))
        {

        }
    }
}
