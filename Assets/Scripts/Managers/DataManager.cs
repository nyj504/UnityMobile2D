using UnityEngine;
using System.Collections.Generic;

public struct ItemData
{
    public int Key;
    public string Name;
    public float ProductionTime;
    public string ProductionUnit;
    public int InputKey1;
    public int InputKey2;
    public int InputAmount1;
    public int InputAmount2;
    public int OutputAmount;
}

public class DataManager : MonoBehaviour
{
    private static DataManager _instance;

    public static DataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DataManager();
            }

            return _instance;
        }
    }

    private Dictionary<int, ItemData> _itemDatas = new Dictionary<int, ItemData>();
    public Dictionary<int, ItemData> ItemDatas
    {
        get { return _itemDatas; }
    }

    public ItemData GetItemData(int key) { return _itemDatas[key]; }

    public void LoadItemData()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Tables/ItemTable");

        string text = textAsset.text;

        string[] rowData = text.Split("\r\n");

        for (int i = 1; i < rowData.Length; i++)
        {
            if (rowData[i].Length == 0)
                break;

            string[] datas = rowData[i].Split(",");

            ItemData data;
            data.Key = int.Parse(datas[0]);
            data.Name = datas[1];
            data.ProductionTime = float.Parse(datas[2]);
            data.ProductionUnit = datas[3];
            data.InputKey1 = int.Parse(datas[4]);
            data.InputKey2 = int.Parse(datas[5]);
            data.InputAmount1 = int.Parse(datas[6]);
            data.InputAmount2 = int.Parse(datas[7]);
            data.OutputAmount = int.Parse(datas[8]);

            _itemDatas.Add(data.Key, data);
        }
    }
}
