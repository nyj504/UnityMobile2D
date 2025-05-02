using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainManager : MonoBehaviour
{
    [SerializeField] private Tilemap _groundTilemap;
    [SerializeField] private Tilemap _highlightTilemap;
    [SerializeField] private TileBase _highlightTile;

    private Vector3Int _prevCellPos;

    private void Awake()
    {
        
    }

    private void Update()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = _groundTilemap.WorldToCell(mouseWorld);

        if (cellPos != _prevCellPos)
        {
            _highlightTilemap.SetTile(_prevCellPos, null);

            if (_groundTilemap.HasTile(cellPos))
            {
                _highlightTilemap.SetTile(cellPos, _highlightTile);
            }

            _prevCellPos = cellPos;
        }
    }
}
