using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

struct item_information
{

    //未完成
    /*
    item_information()
    {
        
    }
    */
}


public class Bag_UI : MonoBehaviour
{
    [SerializeField] private Text item_ui_name;
    [SerializeField] private Text item_ui_weight;
    [SerializeField] private Text item_ui_number;
    [SerializeField] private Text item_ui_description;
    [SerializeField] private Image item_ui_picture;


    void Start()
    {
        GameObject var = GameObject.Find("UI/Bag UI/Item");
        item_ui_name = var.transform.Find("Name").gameObject.GetComponent<Text>();
        item_ui_weight = var.transform.Find("Weight").gameObject.GetComponent<Text>(); ;
        item_ui_number = var.transform.Find("Number").gameObject.GetComponent<Text>(); ;
        item_ui_description = var.transform.Find("Description").gameObject.GetComponent<Text>(); ;
        item_ui_picture = var.transform.Find("Picture").gameObject.GetComponent<Image>(); ;
    }
    void Update()
    {

    }
}
