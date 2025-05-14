using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public enum TileStateType
{
    Empty,
    Occupied,
    Mineral
}
public class GridSystem : MonoBehaviour
{
    [SerializeField]
    private Tilemap _tilemap;
    [SerializeField]
    private Color lineColor = Color.white;
    private Vector3Int _prevCellPos;

    public TileBase selectedTile;
    public Color targetColor = Color.black;  

    private Dictionary<Vector3Int, TileStateType> _tileState = new Dictionary<Vector3Int, TileStateType>();
    private void Start()
    {
        DrawGrid();
    }
    private void Update()
    {
         ChangeTileColor();
    }

    public void SetTileInfo(Vector3Int tilemapPos, TileStateType type)
    {
        _tileState[tilemapPos] = type;
    }

    public void DrawGrid()
    {
        Vector3Int mousePos = new Vector3Int((int)Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
           (int)Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        
        BoundsInt bounds = _tilemap.cellBounds;
        Vector3 size = _tilemap.cellSize;
        Vector3 mouseToCellPosition = _tilemap.CellToWorld(new Vector3Int(mousePos.x, mousePos.y, 0));
       

        for (int x = bounds.xMin; x <= bounds.xMax; x++)
        {
            Vector3 start = _tilemap.CellToWorld(new Vector3Int(x, bounds.yMin, 0));
            Vector3 end = _tilemap.CellToWorld(new Vector3Int(x, bounds.yMax, 0));
            Debug.DrawLine(start, end, lineColor, 100f);
        }

        for (int y = bounds.yMin; y <= bounds.yMax; y++)
        {
            Vector3 start = _tilemap.CellToWorld(new Vector3Int(bounds.xMin, y, 0));
            Vector3 end = _tilemap.CellToWorld(new Vector3Int(bounds.xMax, y, 0));
            Debug.DrawLine(start, end, lineColor, 100f);
        }

        
    }

    public void ChangeTileColor()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;  

        Vector3Int cellPos = _tilemap.WorldToCell(mouseWorldPos);

        Tile currentTile = _tilemap.GetTile<Tile>(cellPos);
        if (currentTile == null) return;

        if (_prevCellPos != cellPos)
        {
            Tile prevTile = _tilemap.GetTile<Tile>(_prevCellPos);
            if (prevTile != null)
            {
                Tile resetTile = Instantiate(prevTile);
                resetTile.color = Color.white;
                _tilemap.SetTile(_prevCellPos, resetTile);
            }
        }

        Tile newTile = Instantiate(currentTile);
        newTile.color = Color.blue;
        _tilemap.SetTile(cellPos, newTile);

        _prevCellPos = cellPos;
    }
}
