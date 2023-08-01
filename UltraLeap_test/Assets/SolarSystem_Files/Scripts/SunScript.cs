using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    [SerializeField] Transform sunTransform;
    [SerializeField] float sunRotationSpeed = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateSun();
    }

    private void RotateSun()
    {
        sunTransform.transform.Rotate(transform.up * sunRotationSpeed * Time.deltaTime);
    }
}
