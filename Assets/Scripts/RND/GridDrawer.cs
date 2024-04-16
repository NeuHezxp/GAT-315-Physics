using UnityEngine;

public class GridDrawer : MonoBehaviour
{
    public int gridWidth = 10;
    public int gridHeight = 10;
    public float cellSize = 1.0f;
    public Material lineMaterial; // Assign a material in the inspector

    private void Start()
    {
        DrawGrid();
    }

    void DrawGrid()
    {
        for (int i = 0; i <= gridWidth; i++)
        {
            CreateLine(i * cellSize, 0, i * cellSize, gridHeight * cellSize);
        }
        for (int j = 0; j <= gridHeight; j++)
        {
            CreateLine(0, j * cellSize, gridWidth * cellSize, j * cellSize);
        }
    }

    void CreateLine(float startX, float startY, float endX, float endY)
    {
        GameObject lineObj = new GameObject("GridLine");
        lineObj.transform.parent = transform;

        LineRenderer lineRenderer = lineObj.AddComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.positionCount = 2;

        Vector3 start = new Vector3(startX, 0.1f, startY); // Slightly above the plane to avoid z-fighting
        Vector3 end = new Vector3(endX, 0.1f, endY);
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
}
