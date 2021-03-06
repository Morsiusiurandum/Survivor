using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    public enum PhysicalCondition { Hurt, Thirst, Hunger, Weak, None ,Cold};
    public PhysicalCondition HeroCondition;
    void Start()
    {
        HeroCondition = PhysicalCondition.None;
    }

    void Update()
    {
     if (HeroCondition == PhysicalCondition.Hunger)
        {
            PlayerValue.Player_Run_Speed = 5;
            PlayerValue.Player_Walk_Speed = 2;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
         if(collision.gameObject.name == "Cube")
        {
            HeroCondition = PhysicalCondition.Hunger;
        }
    }

}
