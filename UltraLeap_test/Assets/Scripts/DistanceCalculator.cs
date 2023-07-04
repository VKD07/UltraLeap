using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    [SerializeField] Transform handPos;
    [SerializeField] Vector3 startPos;
    [SerializeField] Transform rotatingCube;
    [SerializeField] float distance;
    [SerializeField] float startingDistance;
    [SerializeField] GameObject leftHand;
    [SerializeField] bool started;
    void Start()
    {
        startPos = handPos.position;
        startingDistance = Vector3.Distance(startPos, handPos.position);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(startPos, handPos.position);

        if (leftHand.activeSelf && !started)
        {
            started = true;
            startingDistance = startingDistance = Vector3.Distance(startPos, handPos.position);
        }else if(!leftHand.activeSelf && started)
        {
            started = false;
            startingDistance = 0;
        }


        if (distance >  startingDistance && started )
        {
            rotatingCube.Rotate(Vector3.right);
        }else if(distance < startingDistance && started)
        {
            rotatingCube.Rotate(Vector3.left);
        }
    }
}
