using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    CharacterController CC;
    public Text text;
    public GameObject Head, Body;
    public float MoveSpeed;
    public float xRotation, yRotation;
 
    void Start()
    {
        CC = GetComponent<CharacterController>();
    }


    void Update()
    {
        //为物体计算速度
        var Horizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        var Vertical = Input.GetAxis("Vertical") * Time.deltaTime;
        Vector3 Speed = (Vertical * transform.forward + Horizontal * transform.right);
        //模拟重力
        if (!CC.isGrounded)
        {
            CC.Move(-transform.up * Time.deltaTime * 9.8f);
        }
        //移动
        CC.Move(Speed * MoveSpeed);

        //Cursor.lockState = CursorLockMode.Locked;

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
            Head.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

            //绘制射线
            Ray ray = new Ray(Head.transform.position, Head.transform.forward);
            bool isCollider = Physics.Raycast(ray, out RaycastHit hit, 10, 1 << 8);
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 10);
            //显示碰撞名字
            if (isCollider)
            {
                text.text = hit.collider.gameObject.name;
            }
            else
            {
                text.text = "none";
            }
            //捡起物体
            if (isCollider)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    hit.collider.gameObject.SetActive(false);
                }

            }
            int test = PublicVariables.globle;
            //Debug.Log(test);
            PublicVariables.globle = 3;
        }


        //Tab按键检测
        if (Input.GetKey(KeyCode.Tab))
        {
            PublicVariables.TabDown = true;
        }
        else
        {
            PublicVariables.TabDown = false;
        }
    }

   
}
