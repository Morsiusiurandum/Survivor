using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

struct item
{
    readonly internal string name;
    private byte number;

    internal byte num()
    {
        return number;
    }
    internal void add_number(byte num)
    {
        number += num;
    }

    item(string new_name, byte new_num)
    {
        name = new_name;
        number = new_num;
    }
}
public class PlayerBag : MonoBehaviour
{
    internal List<item> props = new List<item>();
    void Start()
    {

    }
    private void Update()
    {

    }
    void Data_Update(item new_item)
    {
        for (int i = 0; i < props.Count; i++)
        {
            if (props[i].name == new_item.name)
            {
                props[i].add_number(new_item.num());
                return;
            }
        }

        props.Add(new_item);
    }
}