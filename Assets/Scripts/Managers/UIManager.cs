using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject _selectionUIPanel;
    private GameObject _buildUIPanel;
    private ProductionUI _productionUI;
    private Image _image;
    private Image _itemImage;
    private TextMeshProUGUI _productionInfo;

    private static UIManager _instance;
    public static UIManager Instance
    { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
        _selectionUIPanel = transform.Find("SelectionUIPanel").gameObject;
        _buildUIPanel = transform.Find("BuildMenu").gameObject;

        _image = _selectionUIPanel.GetComponent<Image>();
        _itemImage = _selectionUIPanel.transform.Find("ItemImage").GetComponent<Image>();
        _productionInfo = _selectionUIPanel.transform.Find("ProductionInfo").GetComponent<TextMeshProUGUI>();

        _productionUI = _selectionUIPanel.GetComponentInChildren<ProductionUI>(true);

        _selectionUIPanel.SetActive(false);
        _buildUIPanel.SetActive(false);
    }

    public void ShowSelectionUI(ItemData data)
    {
        _selectionUIPanel.SetActive(true);

        _image.sprite = Resources.Load<Sprite>("UI/" + "ProductionUI");
        Sprite sprite = Resources.Load<Sprite>("Items/" + "Copper_Plate");
        _itemImage.sprite = sprite;
        _productionInfo.text = $"{data.ProductionTime} {data.ProductionUnit} {data.OutputAmount}";
    }

    public void ShowBuildUI()
    {
        _buildUIPanel.SetActive(true);
    }
}
