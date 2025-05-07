using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum TileStateType 
{ 
    Empty, 
    Occupied, 
    Mineral
}

public class TileInfo
{
    public TileStateType State;
    public GameObject OccupiedObject;
}

public class TileState : MonoBehaviour
{
    [SerializeField]
    private Tilemap _groundMap;
    private Tilemap _mineralMap;

    private Dictionary<Vector3Int, TileInfo> _tilemaps = new Dictionary<Vector3Int, TileInfo>();

    private void Start()
    {
        LoadAllTiles();
    }
    private void LoadAllTiles()
    {
        BoundsInt bounds = _groundMap.cellBounds;
        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                if (_groundMap.HasTile(pos))
                {
                    _tilemaps[pos] = new TileInfo
                    {
                        State = TileStateType.Empty,
                        OccupiedObject = null
                    };
                }
            }
        }
        bounds = _mineralMap.cellBounds;
        
        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                if (_mineralMap.HasTile(pos))
                {
                    _tilemaps[pos] = new TileInfo
                    {
                        State = TileStateType.Mineral,
                        OccupiedObject = null
                    };
                }
            }
        }
    }
    private void LotTiles(Tilemap tilemap)
    {

    }
}
