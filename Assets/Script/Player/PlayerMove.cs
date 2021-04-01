using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mors;

public class PlayerMove : MonoBehaviour
{
    private CharacterController character_controller;
    private Text text;
    private GameObject eyes, body;
    private float y_rotation, x_rotation;

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
    ///当仅满足奔跑条件时为真 
    /// </param>
    /// <param name="meet_walk_condition">
    /// 当仅满足行走条件时为真
    /// </param>
    private void Character_Move(bool meet_run_condition,bool meet_walk_condition)
    {
        //重力模拟
        if (!character_controller.isGrounded) character_controller.Move(-transform.up * Time.deltaTime * 9.8f);
        //移动模拟
        Vector3 final_speed = (Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward) * Time.deltaTime;
        if (final_speed == Vector3.zero)
        {
            PlayerData.player_condition = PlayerCondition.Stand;
        }
        else if (meet_run_condition && !meet_walk_condition)
        {
            character_controller.Move(final_speed * PlayerData.player_run_speed);
            PlayerData.player_condition = PlayerCondition.Run;
        }
        else if (!meet_run_condition && meet_walk_condition)
        {
            character_controller.Move(final_speed * PlayerData.player_walk_speed);
            PlayerData.player_condition = PlayerCondition.Walk;
        }
    }

    /// <summary>
    /// 角色视角转换器
    /// </summary>
    /// <param name="meet_move_condition">
    /// 满足视角时为真
    /// </param>
    private void Eyes_Move(bool meet_move_condition)
    {
        if (!meet_move_condition) return;
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

    void Start()
    {
        Get_Component();
    }


    void Update()
    {
        Character_Move(false,true);
        Eyes_Move(true);
    }
}
