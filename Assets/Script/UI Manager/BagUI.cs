﻿using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BagUI : MonoBehaviour
{

    private GameObject var;
    [SerializeField] private TextMeshProUGUI item_ui_name;
    [SerializeField] private TextMeshProUGUI item_ui_weight;
    [SerializeField] private TextMeshProUGUI item_ui_number;
    [SerializeField] private TextMeshProUGUI item_ui_description;
    [SerializeField] private RawImage item_ui_picture;

    [SerializeField]  private Button[] item_buttons = new Button[7];


    private void Get_Component()
    {
        var = GameObject.Find("UI/Bag UI/Item");
        item_ui_name = var.transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>();
        item_ui_weight = var.transform.Find("Weight").gameObject.GetComponent<TextMeshProUGUI>();
        item_ui_number = var.transform.Find("Number").gameObject.GetComponent<TextMeshProUGUI>();
        item_ui_description = var.transform.Find("Description").gameObject.GetComponent<TextMeshProUGUI>();
        item_ui_picture = var.transform.Find("Picture").gameObject.GetComponent<RawImage>();

        item_buttons = GameObject.Find("UI/Bag UI/ShowItem").GetComponentsInChildren<Button>();
    }

    private void Load_Item_Data()
    {
        int props_number = PlayerData.props_value.Count;
        for(int i = props_number; i < item_buttons.Length; i++)
        {
            item_buttons[i].gameObject.SetActive(false);
        }
   
    }

    private void Show_Item_Information(int item_index)
    {
        item_ui_name.text = PlayerData.props_value[item_index].name;
    }
    public void Click_Button()
    {
        Button var_button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        int button_index = Array.IndexOf(item_buttons, var_button);

        Show_Item_Information(button_index);
    }
    private void Start()
    {

        Get_Component();
        Load_Item_Data();


    }
    void Update()
    {

       
    }
}
