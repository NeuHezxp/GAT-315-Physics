using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    public GameObject hexPrefab;   // Assign your hex prefab in the inspector
    public int gridWidth = 10;
    public int gridHeight = 10;
    public float hexWidth = 2.0f;
    public float hexHeight = 1.75f; // Adjust this based on actual height

    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0, i = 0; i < gridWidth; i++)
        {
            for (int y = 0, j = 0; j < gridHeight; j++)
            {
                GameObject hex = Instantiate(hexPrefab);
                Vector2 hexPosition = HexOffset(i, j);
                hex.transform.position = new Vector3(hexPosition.x, 0, hexPosition.y);
                hex.transform.parent = this.transform;
            }
        }
    }

    Vector2 HexOffset(int x, int y)
    {
        Vector2 position = Vector2.zero;
        float xOffset = x * hexWidth * 0.75f; // 0.75 for horizontal spacing adjustment
        float yOffset = y * hexHeight + (x % 2 == 0 ? 0 : hexHeight / 2); // Adjust row shifting
        position.x = xOffset;
        position.y = yOffset;
        return position;
    }
}
