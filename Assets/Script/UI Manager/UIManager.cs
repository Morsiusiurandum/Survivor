using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mors;

public class UIManager : MonoBehaviour
{
    public GameObject ui;
    [SerializeField] private Canvas main_ui;
    [SerializeField] private Canvas pasue_ui;
    [SerializeField] private Canvas bag_ui;

    /// <summary>
    /// 加载每个画布
    /// </summary>
    internal void Load_All_Canvas()
    {
        ui = GameObject.Find("UI");
        main_ui = ui.transform.Find("Main UI").gameObject.GetComponent<Canvas>();
        pasue_ui = ui.transform.Find("Pause UI").gameObject.GetComponent<Canvas>();
        bag_ui = ui.transform.Find("Bag UI").gameObject.GetComponent<Canvas>();
    }

    internal void Change_Different_Canvas(GameCanvas from, GameCanvas to)
    {
        
    }


    void Start()
    {
        Load_All_Canvas();
    }


    void Update()
    {


    }

}
