using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class ProductionUI : MonoBehaviour
{
    private TextMeshProUGUI _productionInfo;
    private Image _image;
    private Image _itemImage;
    private ItemData _itemData;

    private void Awake()
    {
        _image = GetComponent<Image>();

        _productionInfo = transform.Find("ProductionInfo").GetComponent<TextMeshProUGUI>();
        _itemImage = transform.Find("ItemImage").GetComponent<Image>();
    }

    public void SetUIComponents()
    {
        string path = "Items/Copper_Plate";

        _itemData = DataManager.Instance.GetItemData(3);

        Sprite sprite = Resources.Load<Sprite>(path);

        _itemImage.sprite = sprite;

        //_nameText.text = _itemData.Name;
        _productionInfo.text = $"{_itemData.ProductionTime} {_itemData.ProductionUnit} {_itemData.OutputAmount}";
    }
}
