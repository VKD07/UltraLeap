using JetBrains.Annotations;
using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateAnObject : MonoBehaviour
{
    [SerializeField] bool createObject;
    [SerializeField] Transform objectSpawnPoint;
    [SerializeField] PrimitiveType typeOfObj;
    [SerializeField] GameObject objectToCreate;

    [Header("Materials")]
    [SerializeField] Material wireFrameMat;
    [SerializeField] Material defaultMaterial;
    DragObject dragScript;
    GameObject createdObj;
    bool creatingObj;
    private void Start()
    {
        dragScript = GetComponent<DragObject>();
    }

    void Update()
    {
        if (dragScript.pinchLeft && dragScript.pinchRight && dragScript.distance > 0.10f && !creatingObj)
        {
            creatingObj = true;
            createdObj = GameObject.CreatePrimitive(typeOfObj);
           // createdObj = Instantiate(objectToCreate);
            createdObj.AddComponent<Rigidbody>();
            createdObj.AddComponent<InteractionBehaviour>();
            createdObj.GetComponent<Rigidbody>().isKinematic = true;
            createdObj.GetComponent<MeshRenderer>().material = wireFrameMat;
        }

        if (dragScript.pinchLeft && dragScript.pinchRight && createdObj != null)
        {
            createdObj.transform.localScale = new Vector3(dragScript.distance, dragScript.distance, dragScript.distance);
            createdObj.transform.position = objectSpawnPoint.position;
        }
    }

    public void TypeOfObj(string type)
    {
        switch (type)
        {
            case "cube":
                typeOfObj = PrimitiveType.Cube;
            break;

            case "sphere":
                typeOfObj = PrimitiveType.Sphere;
            break;
        }
    }

    public void CreateObject(bool value)
    {
        createObject = value;
    }

    public void CreatingObject(bool value)
    {
        createdObj.GetComponent<MeshRenderer>().material = defaultMaterial;
        createdObj.GetComponent<Rigidbody>().isKinematic = false;
        createdObj = null;
        creatingObj = value;
    }
}
