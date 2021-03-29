using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    CharacterController CC;
    public Text text;
    internal GameObject Eyes, Body;
    internal float MoveSpeed;
    internal float xRotation, yRotation;


    private void Character_Move(float horizontal_parameter, float vertical_parameter)
    {
        Vector3 Speed = (horizontal_parameter * transform.forward + vertical_parameter * transform.right);
        if (Speed != Vector3.zero)
        {

        }
    }


    void Start()
    {
        CC = GetComponent<CharacterController>();
        Eyes = GameObject.Find("Player/Body/Eyes");
        Body = GameObject.Find("Player");
    }


    void Update()
    {
        var Horizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        var Vertical = Input.GetAxis("Vertical") * Time.deltaTime;
        Vector3 Speed = (Vertical * transform.forward + Horizontal * transform.right);
        if (Speed == Vector3.zero)
        {
            PlayerValue.Player_Condition = PlayerCondition.Stand;
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift) && PlayerValue.Player_Strength_Value > 0)
            {
                CC.Move(Speed * PlayerValue.Player_Run_Speed);
                PlayerValue.Player_Condition = PlayerCondition.Run;
            }
            else
            {
                CC.Move(Speed * PlayerValue.Player_Walk_Speed);
                PlayerValue.Player_Condition = PlayerCondition.Walk;
            }
        }




        //模拟重力
        //
        if (!CC.isGrounded)
        {
            CC.Move(-transform.up * Time.deltaTime * 9.8f);
        }


        //视角移动
        if (!Input.GetKey(KeyCode.Tab))
        {
            var Mouse_X = Input.GetAxis("Mouse X") * BaseSetting.MouseSensitivity * Time.deltaTime;
            var Mouse_Y = Input.GetAxis("Mouse Y") * BaseSetting.MouseSensitivity * Time.deltaTime;

            xRotation = xRotation - Mouse_Y;
            xRotation = Mathf.Clamp(xRotation, -50f, 50f);
            yRotation = yRotation + Mouse_X;
            //身体左右旋转
            Body.transform.rotation = Quaternion.Euler(0, yRotation, 0);
            //头部同步左右旋转且上下点
            Eyes.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

            //绘制射线
            PublicVariables.ray = new Ray(Eyes.transform.position, Eyes.transform.forward);


        }


    }
}
