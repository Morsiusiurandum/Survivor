using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerBag : MonoBehaviour
{
    public ArrayList BagList = new ArrayList();
    internal Text item_name;
    void Start()
    {
        item_name = GameObject.Find("UI/Main UI/Text").GetComponent<Text>();
    }
    void Update()
    {
       

        ShowBag(Input.GetKey(KeyCode.B));
    }
   
    void ShowBag(bool press_key)
    {
        if (press_key)
        {
            item_name.text = BagList[0].ToString();
        }
        else
        {
            item_name.text = null;
        }
    }
}