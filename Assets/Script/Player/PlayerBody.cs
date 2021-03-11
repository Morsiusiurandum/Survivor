using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//write only
public class PlayerBody : MonoBehaviour
{
    public enum PhysicalCondition { Hurt, Thirst, Hunger, Weak, None, Cold };

    void FixedUpdate()
    {

        //模拟饥饿干渴
        if (PlayerValue.Player_Hunger_Value < 100)
        {
            PlayerValue.Player_Hunger_Value = PlayerValue.Player_Hunger_Value + Time.deltaTime * 4;
        }
        if (PlayerValue.Player_Thirst_Value < 100)
        {
            PlayerValue.Player_Thirst_Value = PlayerValue.Player_Thirst_Value + Time.deltaTime * 4;
        }
        //模拟体力消耗
        Strength_System.Consume(PlayerValue.Player_Condition);
    }


}
class Strength_System
{
    internal static void Consume(PlayerCondition condition)
    {
        //消耗系数
        float consumption_factor = 0;
        //为不同状况下的体力消耗系数赋值
        switch (condition)
        {
            case PlayerCondition.Walk:
                consumption_factor = 1;
                break;
            case PlayerCondition.Run:
                consumption_factor = 3;
                break;
            case PlayerCondition.Stand:
                consumption_factor = -1.5f;
                break;

        }
        //计算体力消耗
       if(PlayerValue.Player_Strength_Value > 0 && PlayerValue.Player_Strength_Value < 100)
        {
            PlayerValue.Player_Strength_Value -= consumption_factor * Time.deltaTime;
        }
    }

    
}