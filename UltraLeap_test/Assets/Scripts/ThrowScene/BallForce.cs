using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallForce : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float force = 20f;
    bool ballGrabed;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void AddBallForce()
    {
        if (ballGrabed)
        {
            rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
        }
    }

    public void GrabBall()
    {
        ballGrabed = true;
    }
}
