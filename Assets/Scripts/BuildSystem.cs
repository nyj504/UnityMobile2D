using NUnit.Framework;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildSystem : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject[] _buildingPrefabs;
    private GameObject _overviewBuilding;
    private List<GameObject> _buildings = new List<GameObject>();
    private bool _isClickBuilding = false;
    private bool _isHoldBuilding = false;
    private int _buildingIndex = 0;
    private SpriteRenderer _spriteRenderer;
    private GridSystem _gridSystem;

    private bool _showGrid = false;

    private void Awake()
    {
        _buildingPrefabs = Resources.LoadAll<GameObject>("Prefabs/Buildings");
    }

    private void Start()
    {
        _gridSystem = GetComponent<GridSystem>();
    }
    private void Update()
    {
        if (_isClickBuilding)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3Int cellPos = tilemap.WorldToCell(mousePos);
            Vector3 cellWorldCenter = tilemap.GetCellCenterWorld(cellPos);

            if (_gridSystem.GetTileState(cellPos) == TileStateType.Empty)
            {
                _spriteRenderer.color = Color.green;
            }
            else
            {
                _spriteRenderer.color = Color.red;
            }

            _overviewBuilding.transform.position = mousePos;
           
            if (Input.GetMouseButtonDown(0)) 
            {
                _isClickBuilding = false;
                _buildingIndex = -1;

                _overviewBuilding.transform.position = cellWorldCenter;

                _buildings.Add(_overviewBuilding);

                _gridSystem.SetTileInfo(cellPos, TileStateType.Occupied);
            }
        }
    }

    public void OnClickBuilding(int index)
    {
        _isClickBuilding = true;
        _buildingIndex = index;
       
        GameObject newobj = Instantiate(_buildingPrefabs[_buildingIndex], new Vector3(0, 0, 0), Quaternion.identity);
        _overviewBuilding = newobj;
        _spriteRenderer = _overviewBuilding.GetComponent<SpriteRenderer>();
    }
}
