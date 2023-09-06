using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class NormalizeLinePoints : MonoBehaviour
{

    LineRenderer lineRenderer;
    [SerializeField] int Zpos = 1;

    void Update()
    {
        lineRenderer = GetComponent<LineRenderer>();
        int pointCount = lineRenderer.positionCount;
        List<Vector3> points = new List<Vector3>();

        for (int point = 0; point < pointCount; point++)
        {
            Vector3 currentPoint = lineRenderer.GetPosition(point);
            points.Add(currentPoint);
        }
        if (points.Count == pointCount)
        {
            for (int point = 0; point < pointCount; point++)
            {
                Vector3 currentPosition = points[point];
                Vector3 newPosition = new Vector3(currentPosition.x, currentPosition.y, Zpos);
                lineRenderer.SetPosition(point, newPosition);
            }
        }
    }
}
