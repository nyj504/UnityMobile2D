using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameObject _selectionUIPanel;
    private ProductionUI _productionUI;

    private static UIManager _instance;
    public static UIManager Instance
    { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
        _selectionUIPanel = transform.Find("SelectionUIPanel").gameObject;
        //_productionUI 

        _productionUI = _selectionUIPanel.GetComponentInChildren<ProductionUI>(true);
    }

    private void Start()
    {
        SetUI();
    }


    private void SetUI()
    {

        _productionUI.SetUIComponents();
        //HashSet<int> usedKeys = new HashSet<int>();

        //for (int i = 0; i < _cards.Count; i++)
        //{
        //    _cards[i].onClickWeaponCard = null;
        //    int randKey;
        //    do
        //    {
        //        randKey = UnityEngine.Random.Range(1001, 1009);
        //    }
        //    while (usedKeys.Contains(randKey));

        //    usedKeys.Add(randKey);
        //    _cards[i].SetStatusCardData(randKey);

        //    _cards[i].onClickStatusCard = () =>
        //    {
        //        Debug.Log("StatusCard");
        //        GameManager.PlayerInstance.EnhancePlayerStatus(randKey);

        //        _choicePanel.SetActive(false);
        //        _waveIndex++;
        //    };
        //}
    }
}
