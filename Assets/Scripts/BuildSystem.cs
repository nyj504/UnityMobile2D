using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    public Grid grid;
    [SerializeField]
    private GameObject _factorySelectPanel;

    [SerializeField]
    private GameObject[] _factoryPrefabs;
    [SerializeField]
    private GameObject _ghostFactoryInstance;
    [SerializeField]
    private GameObject _ghostFactoryPrefab;

    private GameObject _currentGhost;
    private GameObject _selectedFactory;

    private void Update()
    {
        if (_currentGhost != null)
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = 0;

            Vector3Int cellPos = grid.WorldToCell(mouseWorld);
            _currentGhost.transform.position = grid.CellToWorld(cellPos);

            if (Input.GetMouseButtonDown(0))
            {
                if (IsValidPlacement(cellPos))
                {
                    Instantiate(_selectedFactory, _currentGhost.transform.position, Quaternion.identity);
                }
            }
        }
    }
    public void OnBuildButtonClick()
    {
        _factorySelectPanel.SetActive(true);
    }

    public void SelectFactory(int factoryIndex)
    {
        _selectedFactory = _factoryPrefabs[factoryIndex];
        _ghostFactoryPrefab = _selectedFactory; 

        if (_currentGhost != null)
            Destroy(_currentGhost);

        _currentGhost = Instantiate(_ghostFactoryPrefab);
        _currentGhost.GetComponent<Collider2D>().enabled = false;
        _currentGhost.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f); 

        _factorySelectPanel.SetActive(false);
    }

    bool IsValidPlacement(Vector3Int cell)
    {
        return true;
    }

}
