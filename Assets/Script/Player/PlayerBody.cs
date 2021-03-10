using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    public enum PhysicalCondition { Hurt, Thirst, Hunger, Weak, None ,Cold};
    //public PhysicalCondition HeroCondition;
    void Start()
    {
        //HeroCondition = PhysicalCondition.None;
    }

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
       
        
       /* if (HeroCondition == PhysicalCondition.Hunger)
        {
            PlayerValue.Player_Run_Speed = 5;
            PlayerValue.Player_Walk_Speed = 2;
        }*/
    }
    private void OnTriggerEnter(Collider collision)
    {
         if(collision.gameObject.name == "Cube")
        {
            //HeroCondition = PhysicalCondition.Hunger;
        }
    }

}
