using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class ProductionUI : MonoBehaviour
{
    private ItemData _itemData; 
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        UIManager.Instance.ShowSelectionUI(_itemData);
    }
}
