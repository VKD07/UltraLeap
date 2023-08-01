using JetBrains.Annotations;
using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectCreation : MonoBehaviour
{
    [SerializeField] Transform objectSpawnPoint;
    [SerializeField] GameObject objectToCreate;
    [SerializeField] float sizeIncreaseRate = 0.5f;

    [Header("Fingers")]
    [SerializeField] Transform fingerRight;
    [SerializeField] Transform fingerLeft;
    [SerializeField] float fingerDistance;
    [SerializeField] bool pinchRight;
    [SerializeField] bool pinchLeft;

    [Header("Materials")]
    [SerializeField] Material wireFrameMat;
    [SerializeField] Material defaultMaterial;
    [SerializeField] Material redMaterial;
    Material createdObjMat;
    GameObject createdObj;
    float randomDistance;
    bool creatingObj;

    void Update()
    {
        CreateAnObject();
        ResizeTheObject();
    }
    private void CreateAnObject()
    {
        if (pinchLeft && pinchRight && fingerDistance > 0.10f && !creatingObj)
        {
            creatingObj = true;
            createdObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            createdObj.AddComponent<Rigidbody>();
            //  createdObj.AddComponent<InteractionBehaviour>();
            randomDistance = Random.Range(20f, 70f);
            createdObj.AddComponent<CreatedObjectScript>();
            createdObj.GetComponent<CreatedObjectScript>().distanceFromTheSun = randomDistance;
            createdObj.GetComponent<Rigidbody>().isKinematic = true;
            createdObj.GetComponent<MeshRenderer>().material = wireFrameMat;
        }
    }
    private void ResizeTheObject()
    {
        fingerDistance = Vector3.Distance(fingerLeft.position, fingerRight.position);
        if (pinchLeft && pinchRight && createdObj != null)
        {
            createdObj.transform.localScale = new Vector3(fingerDistance, fingerDistance, fingerDistance) * sizeIncreaseRate;
            createdObj.transform.position = objectSpawnPoint.position;
        }
    }

    public void IsPinchingRight(bool value)
    {
        pinchRight = value;
    }

    public void IsPinchingLeft(bool value)
    {
        pinchLeft = value;
    }

    public void CreatingObject(bool value)
    {
        createdObj.GetComponent<MeshRenderer>().material = createdObjMat;
        createdObj = null;
        creatingObj = value;
    }

    public void ChangeColorDefault()
    {
        createdObjMat = defaultMaterial;
    }
    public void ChangeColorRed()
    {
        createdObjMat = redMaterial;
    }

}
