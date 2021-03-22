using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[Serializable]
struct item_information
{
    public string description_information;
    public float weight_information;
};

public class Bag_UI : MonoBehaviour
{
    item_information testA = new item_information();

    [SerializeField] private TextMeshProUGUI item_ui_name;
    [SerializeField] private TextMeshProUGUI item_ui_weight;
    [SerializeField] private TextMeshProUGUI item_ui_number;
    [SerializeField] private TextMeshProUGUI item_ui_description;
    [SerializeField] private RawImage item_ui_picture;
    public GameObject var;
    void Awake()
    {
         var = GameObject.Find("UI/Bag UI/Item");
        item_ui_name = var.transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>();
        item_ui_weight = var.transform.Find("Weight").gameObject.GetComponent<TextMeshProUGUI>();
        item_ui_number = var.transform.Find("Number").gameObject.GetComponent<TextMeshProUGUI>();
        item_ui_description = var.transform.Find("Description").gameObject.GetComponent<TextMeshProUGUI>();
        item_ui_picture = var.transform.Find("Picture").gameObject.GetComponent<RawImage>();

        try
        {
            using (StreamReader sr = new StreamReader("C:/Users/Mors/Desktop/Information.txt"))
            {
                string json_read;
                while ((json_read = sr.ReadLine()) != null)
                {
                    testA = JsonUtility.FromJson<item_information>(json_read);
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    void Update()
    {

        item_ui_name.text = PlayerValue.props_value[0].name;
        item_ui_weight.text = (PlayerValue.props_value[0].num * testA.weight_information).ToString();
        item_ui_number.text = PlayerValue.props_value[0].num.ToString();
        item_ui_description.text = testA.description_information;

       /* try
        {
            using (StreamWriter sw = new StreamWriter("C:/Users/Mors/Desktop/Information.txt"))
            {
                sw.WriteLine(JsonUtility.ToJson(testA));
            }
        }
        catch (Exception e)
        {

            Debug.Log(e.Message);
        }*/
    }
}
