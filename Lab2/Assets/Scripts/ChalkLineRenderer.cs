using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using VRTK;
using Unity;

public class ChalkLineRenderer : MonoBehaviour
{ 
    private LineRenderer lineRenderer;
    public float minimumVertexDistance = 0.05f;
    private Transform chalkTip;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        chalkTip = gameObject.transform.GetChild(0);
    }

    void Update()
    {
        
        float distance = Vector3.Distance(chalkTip.position,
            lineRenderer.GetPosition((lineRenderer.positionCount - 1)));
        if (distance > minimumVertexDistance)
        {
            Debug.Log(distance);
            UpdateLine();
        }

    }

    private void onEnable()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, chalkTip.position);
        lineRenderer.SetPosition(1, chalkTip.position);
    }

    private void UpdateLine()
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, chalkTip.position);
    }
}
