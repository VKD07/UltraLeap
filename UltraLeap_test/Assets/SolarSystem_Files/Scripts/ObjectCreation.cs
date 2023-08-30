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
    [SerializeField] Material blueMaterial;
    Material createdObjMat;
    GameObject createdObj;
    bool creatingObj;
    bool colorChosen;

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
            createdObj = Instantiate(objectToCreate);
            //createdObj.AddComponent<Rigidbody>();
            //createdObj.AddComponent<InteractionBehaviour>();
            //createdObj.AddComponent<CreatedObjectScript>();
            createdObj.GetComponent<CreatedObjectScript>().distanceFromTheSun = Random.Range(20f, 70f);
            createdObj.GetComponent<CreatedObjectScript>().rotationSpeed = Random.Range(20, 50f);
            //createdObj.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    private void ResizeTheObject()
    {
        fingerDistance = Vector3.Distance(fingerLeft.position, fingerRight.position);
        if (pinchLeft && pinchRight && createdObj != null)
        {
            createdObj.transform.localScale = new Vector3(fingerDistance, fingerDistance, fingerDistance) * sizeIncreaseRate;
            createdObj.transform.position = objectSpawnPoint.position;
            createdObj.GetComponent<MeshRenderer>().material = wireFrameMat;
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
        if (!colorChosen)
        {
            createdObjMat = defaultMaterial;
        }
        createdObj.GetComponent<MeshRenderer>().material = createdObjMat;
        createdObj = null;
        creatingObj = value;
    }

    public void ChangeColorDefault()
    {
        colorChosen = true;
        createdObjMat = defaultMaterial;
    }
    public void ChangeColorRed()
    {
        colorChosen = true;
        createdObjMat = redMaterial;
    }

    public void BlueColor()
    {
        colorChosen = true;
        createdObjMat = blueMaterial;
    }
}
