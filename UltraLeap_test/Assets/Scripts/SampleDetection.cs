using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SampleDetection : MonoBehaviour
{
    [SerializeField] float radiusValue = 1;
    [SerializeField] Vector3 boxSize;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
     void OnGUI()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        //Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, radiusValue);
        Gizmos.DrawWireCube(transform.position, boxSize);
    }
    void OnDrawGizmosSelected()
    {
     
    }
}
