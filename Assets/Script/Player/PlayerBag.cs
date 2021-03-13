using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
struct item
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
        item_number +=num;
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
            item_number += (byte)(var[1][i] - '0');
        }
    }
}
/// <summary>
/// 
/// </summary>
public class PlayerBag : MonoBehaviour
{
    [SerializeField]
    private List<item> props = new List<item>();
    void Start()
    {
        try
        {
            using (StreamReader sr = new StreamReader("C:/Users/Mors/Desktop/DataBase.txt"))
            {
                string SaveJson;
                while ((SaveJson = sr.ReadLine()) != null)
                {
                    Debug.Log(SaveJson);
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log("The file could not be read:");
            Debug.Log(e.Message);
        }
    }
    private void Update()
    {
        Get_Item(Input.GetKeyDown(KeyCode.Mouse0));
    }
    /// <summary>
    /// 
    /// </summary>
    void Data_Update(item new_item)
    {
        //*****BUG
        for (int i = 0; i < props.Count; i++)
        {
            if (props[i].name == new_item.name)
            {
                props[i].add_number(new_item.num);
                return;
            }
        }
        //*****BUG
        /// 无法更改存入list的值
        props.Add(new_item);
    }
    void Get_Item(bool KeyInput)
    {
        if (!KeyInput) return;
        bool isCollider = Physics.Raycast(PublicVariables.ray, out RaycastHit hit, 10, 1 << 8);
        if (!isCollider) return;
        Data_Update(new item(hit.collider.gameObject.name));
        Destroy(hit.collider.gameObject);
        string json = JsonUtility.ToJson(props);
        Debug.Log(json);
      /* try
        {
            using (StreamWriter sw = new StreamWriter("C:/Users/Mors/Desktop/DataBase.txt"))
            {
                sw.WriteLine(json);
            }
        }
        catch (Exception e)
        {

            Debug.Log(e.Message);
        }*/
    }

    void test()
    {
        Debug.Log(props[0].name);
        Debug.Log(props[0].num.ToString());
    }
}