using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumNamespcae;

public class PlayerMove : MonoBehaviour
{
    private CharacterController character_controller;
    private Text text;
    internal GameObject eyes, body;
    internal float y_rotation, x_rotation;

    /// <summary>
    /// 组件获取函数
    /// </summary>
    private void Get_Component()
    {
        character_controller = GetComponent<CharacterController>();
        eyes = GameObject.Find("Player/Body/Eyes");
        body = GameObject.Find("Player");
    }

    /// <summary>
    /// 角色运动控制器(包括重力模拟
    /// </summary>
    /// <param name="meet_run_condition">
    ///当满足奔跑条件时为真 
    /// </param>
    private void Character_Move(bool meet_run_condition)
    {
        //重力模拟
        if (!character_controller.isGrounded) character_controller.Move(-transform.up * Time.deltaTime * 9.8f);
        //移动模拟
        Vector3 final_speed = (Input.GetAxis("Horizontal") * transform.forward + Input.GetAxis("Vertical") * transform.right) * Time.deltaTime;
        if (final_speed == Vector3.zero)
        {
            PlayerValue.player_condition = PlayerCondition.Stand;
        }
        else if (meet_run_condition)
        {
            character_controller.Move(final_speed * PlayerValue.player_run_speed);
            PlayerValue.player_condition = PlayerCondition.Run;
        }
        else
        {
            character_controller.Move(final_speed * PlayerValue.player_walk_speed);
            PlayerValue.player_condition = PlayerCondition.Walk;
        }
    }



    void Start()
    {
        Get_Component();
    }


    void Update()
    {



        //视角移动
        if (!Input.GetKey(KeyCode.Tab))
        {
            var Mouse_X = Input.GetAxis("Mouse X") * BaseSetting.MouseSensitivity * Time.deltaTime;
            var Mouse_Y = Input.GetAxis("Mouse Y") * BaseSetting.MouseSensitivity * Time.deltaTime;

            y_rotation -= Mouse_Y;
            y_rotation = Mathf.Clamp(y_rotation, -50f, 50f);
            x_rotation += Mouse_X;
            //身体左右旋转
            body.transform.rotation = Quaternion.Euler(0, x_rotation, 0);
            //头部同步左右旋转且上下点
            eyes.transform.rotation = Quaternion.Euler(y_rotation, x_rotation, 0);
            //绘制射线
            PublicVariables.ray = new Ray(eyes.transform.position, eyes.transform.forward);


        }


    }
}
