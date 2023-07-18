using Leap.Unity.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    public Transform point;
    public InteractionSlider interactionSlider;
    LineRender activeLine;
    [SerializeField] List<GameObject> drawings;
    [SerializeField] Material lineMaterial;
    public bool pinch;
    bool drawing;
    bool deleteAll;

    //Raycast
    [SerializeField] Transform rayOrigin;
    [SerializeField] LayerMask layer;
    [SerializeField] float rayDistance = 5f;
    RaycastHit hit;

    void Start()
    {
        LineRenderer prefabLineRenderer = linePrefab.GetComponent<LineRenderer>();
        prefabLineRenderer.startWidth = 0.5f;
        prefabLineRenderer.endWidth = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
      
        AdjustLineWidth();

        RayCast();
    }

    private void DrawLine(Vector3 pos)
    {
        if (pinch && !drawing)
        {
            drawing = true;
            GameObject newLine = Instantiate(linePrefab);
            activeLine = newLine.GetComponent<LineRender>();
            drawings.Add(newLine);
        }

        if (drawing)
        {
            if (activeLine != null)
            {
                activeLine.UpdateLine(pos);
            }
        }

        if (!pinch)
        {
            drawing = false;
            activeLine = null;
        }
    }
    private void AdjustLineWidth()
    {
        linePrefab.GetComponent<LineRenderer>().startWidth = interactionSlider.HorizontalSliderValue;
        linePrefab.GetComponent<LineRenderer>().endWidth = interactionSlider.HorizontalSliderValue;
    }

    void RayCast()
    {
        Ray ray = new Ray(point.position, Vector3.forward);
        if (Physics.Raycast(ray, out hit, rayDistance, layer))
        {
            DrawLine(hit.point);
        }
    }

    public void DeleteAll()
    {
        GameObject[] line = GameObject.FindGameObjectsWithTag("Line");

        for (int i = 0; i < line.Length; i++)
        {
            Destroy(line[i]);
        }

        drawings.Clear();
    }

    public void Undo()
    {
        lineMaterial.color = Color.red;
    }

    public bool StartDraw
    {
        set { pinch = value; }
    }
}
