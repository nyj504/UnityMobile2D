using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildSystem : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject[] _buildingPrefabs;
    public Color lineColor = Color.white;
    private bool _isClickBuilding = false;
    private int _buildingIndex = 0;

    private bool _showGrid = false;

    private void Awake()
    {
        _buildingPrefabs = Resources.LoadAll<GameObject>("Prefabs/Buildings");
    }
    private void Update()
    {
        ShowGrid(true);
        if (_isClickBuilding)
        {
            Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _buildingPrefabs[_buildingIndex].transform.position = MousePos;
        }
    }

    public void ShowGrid(bool show)
    {
        _showGrid = show;
    }

    public void OnClickBuilding(int index)
    {
        _isClickBuilding = true;
        _buildingIndex = index;
    }

    private void OnDrawGizmos()
    {
        if (!_showGrid || tilemap == null) return;

        Gizmos.color = lineColor;


        BoundsInt bounds = tilemap.cellBounds;
        Vector3 size = tilemap.cellSize;

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int cellPos = new Vector3Int(x, y, 0);
                Vector3 cellWorldPos = tilemap.CellToWorld(cellPos);

                Vector3 bottomLeft = cellWorldPos;
                Vector3 bottomRight = cellWorldPos + new Vector3(size.x, 0, 0);
                Vector3 topLeft = cellWorldPos + new Vector3(0, size.y, 0);
                Vector3 topRight = cellWorldPos + new Vector3(size.x, size.y, 0);

                Gizmos.DrawLine(bottomLeft, bottomRight);
                Gizmos.DrawLine(bottomRight, topRight);
                Gizmos.DrawLine(topRight, topLeft);
                Gizmos.DrawLine(topLeft, bottomLeft);
            }
        }
    }

}
