using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform throwPoint;
    public Transform target;
    public GameObject projectile;
    public float timeToHit = 1f;
    float gravity;

    //[SerializeField] GameObject ball;

    //Timer
    float throwTimer;
    public float timeBtwThrows;
    public float rotationSpeed = 1f;

    Transform thisTransform;

    // Start is called before the first frame update
    void Start()
    {
        throwTimer = timeBtwThrows;
        gravity = Mathf.Abs(Physics.gravity.y);
        thisTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = throwPoint.right;
        direction.y = 0f;
        thisTransform.rotation = Quaternion.LookRotation(direction * (rotationSpeed * Time.deltaTime));

        if (throwTimer <= 0)
        {
            throwTimer = timeBtwThrows;
            Throw();
        }
        else
        {
            throwTimer -= Time.deltaTime;
        }
    }

    public void Throw()
    {
        Vector3 requiredVelocity = RequiredInitialVelocity(throwPoint.position, throwPoint.right, timeToHit);
        GameObject tempProjectile = Instantiate(projectile, throwPoint.position, Quaternion.Euler(new Vector3(0,0,0)));
        
        Rigidbody rb = tempProjectile.GetComponent<Rigidbody>();
       
        rb.velocity = requiredVelocity;
        rb.AddTorque(throwPoint.right * 900f);
    }

    Vector3 RequiredInitialVelocity(Vector3 throwPoint, Vector3 target, float time)
    {
        Vector3 distance = target - throwPoint;
        Vector3 distanceXZ = distance;

        distanceXZ.y = 0;

        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;
        float Vxz = (Sxz / time);
        float Vy = (Sy/ time + .5f * gravity * time);
        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;
    }
}
