using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        switch (PlayerValue.Player_Condition)
        {
            case PlayerCondition.Walk:
                if (PlayerValue.Player_Strength_Value > 0)
                {
                    PlayerValue.Player_Strength_Value = PlayerValue.Player_Strength_Value - Time.deltaTime;

                }
                else
                {
                    PlayerValue.Player_Strength_Value = 0;
                }
                break;
            case PlayerCondition.Run:
                if (PlayerValue.Player_Strength_Value > 0)
                {
                    PlayerValue.Player_Strength_Value = PlayerValue.Player_Strength_Value - Time.deltaTime * 20;

                }
                else{
                    PlayerValue.Player_Strength_Value = 0;
                }
                break;
            case PlayerCondition.Stand:
                if (PlayerValue.Player_Strength_Value < 100)
                {
                    PlayerValue.Player_Strength_Value = PlayerValue.Player_Strength_Value + Time.deltaTime;
                }
                else
                {
                    PlayerValue.Player_Strength_Value = 100;
                }

                break;
        }
    }
}
