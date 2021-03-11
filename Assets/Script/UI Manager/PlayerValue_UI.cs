using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//read only
public class PlayerValue_UI : MonoBehaviour
{
    public Slider[] Value = new Slider[5];
    void Start()
    {
        GameObject var = GameObject.Find("UI/Main UI/Player_Value");
        Value = var.GetComponentsInChildren<Slider>();
    }
    void FixedUpdate()
    {

        Value[0].value = PlayerValue.Player_Temperature_Value / 100;
        Value[1].value = PlayerValue.Player_Hunger_Value / 100;
        Value[2].value = PlayerValue.Player_Thirst_Value / 100;
        Value[3].value = PlayerValue.Player_Willpower_Value / 100;
        Value[4].value = PlayerValue.Player_Strength_Value / 100;
    }
    
}

