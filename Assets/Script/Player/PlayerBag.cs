using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mors;

public class PlayerBag : MonoBehaviour
{
    ///<value> 
    ///包装物品的类项
    ///</value>
    [SerializeField] private Serialize serialize_props = new Serialize();

    /// <summary>
    /// 加载存档中的背包物品，加载物品的美术资源
    /// </summary>
    /// <param name="save_path">
    /// 背包存档路径
    /// </param>
  private void Load_Bag_Items(string save_path)
    {
        serialize_props = JsonUtility.FromJson<Serialize>(SimpleFunction.Json_Read(save_path));
        PlayerData.props_value = serialize_props.props;
    }

    /// <summary>
    /// 将新拾取物品加入背包中的物品栏
    /// </summary>
    /// <param name="new_item">
    /// 新拾取的物品
    /// </param>
    private void Bag_Props_Update(item new_item)
    {  
        for (int i = 0; i < serialize_props.props.Count; i++)
        {
            if (serialize_props.props[i].name == new_item.name)
            {
                serialize_props.props[i].add_number(new_item.num);
                return;
            }
        }
        serialize_props.props.Add(new_item);
    }

    private void Pick_Up_Props(bool meet_pick_condition)
    {
        if (!meet_pick_condition) return;

        bool isCollider = Physics.Raycast(PublicVariables.ray, out RaycastHit hit, 10, 1 << 8);
        if (!isCollider) return;

        Bag_Props_Update(new item(hit.collider.gameObject.name));
        Destroy(hit.collider.gameObject);
        PlayerData.props_value = serialize_props.props;
        serialize_props.Load("C:/Users/Mors/Desktop/DataBase.json");
    }

    private void Awake()
    {
        Load_Bag_Items("C:/Users/Mors/Desktop/DataBase.json");
    }

    private void Update()
    {
        Pick_Up_Props(Input.GetKeyDown(KeyCode.Mouse0));
    }

}