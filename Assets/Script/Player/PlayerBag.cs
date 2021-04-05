using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
class item
{
    [SerializeField] private string item_name;
    [SerializeField] private byte item_number;

    internal byte num
    {
        get
        {
            return item_number;
        }
    }
    internal string name
    {
        get
        {
            return item_name;
        }
    }
    internal void add_number(byte num)
    {
        if ((item_number + num) > 255)
        {
            item_number = 255;
        }
        else
        {
            item_number += num;
        }
    }
    //Analysis Data to Struct the item
    internal item(string Data)
    {
        item_number = 0;
        char[] stop = { '_' };
        string[] var = Data.Split(stop, 3);
        item_name = var[0];
        for (int i = 0; i < var[1].Length; i++)
        {
            item_number = (byte)(item_number * 10 + var[1][i] - '0');
        }
    }
}
[Serializable]
class Wrap
{
    [SerializeField]
    internal List<item> props = new List<item>();
}

public class PlayerBag : MonoBehaviour
{
    ///<value> 
    ///包装物品的类项
    ///</value>
    private Wrap wrap_props = new Wrap();

    /// <summary>
    /// 加载存档中的背包物品，加载物品的美术资源
    /// </summary>
    /// <param name="save_path">
    /// 背包存档路径
    /// </param>
    private void Load_Bag_Items(string save_path)
    {
        wrap_props = JsonUtility.FromJson<Wrap>(SimpleFunction.Json_Read(save_path));
        PlayerData.props_value = wrap_props.props;
    }

    /// <summary>
    /// 将新拾取物品加入背包中的物品栏
    /// </summary>
    /// <param name="new_item">
    /// 新拾取的物品
    /// </param>
    private void Bag_Props_Update(item new_item)
    {
        for (int i = 0; i < wrap_props.props.Count; i++)
        {
            if (wrap_props.props[i].name == new_item.name)
            {
                wrap_props.props[i].add_number(new_item.num);
                return;
            }
        }
        wrap_props.props.Add(new_item);
    }


    void Awake()
    {
        Load_Bag_Items("C:/Users/Mors/Desktop/DataBase.txt");
    }
    private void Update()
    {
        Get_Item(Input.GetKeyDown(KeyCode.Mouse0));
    }

    
    void Get_Item(bool KeyInput)
    {
        if (!KeyInput) return;
        bool isCollider = Physics.Raycast(PublicVariables.ray, out RaycastHit hit, 10, 1 << 8);
        if (!isCollider) return;
        Bag_Props_Update(new item(hit.collider.gameObject.name));
        Destroy(hit.collider.gameObject);
        string json = JsonUtility.ToJson(wrap_props);

        try
        {
            using (StreamWriter sw = new StreamWriter("C:/Users/Mors/Desktop/DataBase.txt"))
            {
                sw.WriteLine(json);
            }
        }
        catch (Exception e)
        {

            Debug.Log(e.Message);
        }
    }
}