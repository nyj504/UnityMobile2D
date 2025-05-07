using UnityEngine;

public class BuildingBtn : MonoBehaviour
{
    private BoxCollider2D _collider;
    private ItemData _data;
    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

            if (hit.collider != null)
            {
                UIManager.Instance.ShowSelectionUI(_data);
            }
        }
    }
}
