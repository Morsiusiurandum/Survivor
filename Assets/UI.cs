using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // 放射菜单的变量
    //
    internal float MouseX, MouseY;
    internal int K;
    internal Sprite[] temp = new Sprite[7];
    internal GameObject PieMenu;
    internal CanvasGroup canvasgroup;
    internal Image ImageOfPieMenu;

    //
    //

    void Start()
    {
        PieMenu = GameObject.Find("UI/Pie Menu");
        canvasgroup = PieMenu.GetComponent<CanvasGroup>();
        ImageOfPieMenu = PieMenu.GetComponent<Image>();
        LoadPieMenuSprite();
     }
    void Update()
    {
        UsePieMenu();


    }

    /// <summary>
    /// UI上不同界面的操作函数

    //PieMenu
    void LoadPieMenuSprite()
    {
        for (int i = 0; i < 7; i++)
        {
            temp[i] = Resources.Load<Sprite>("Material/temp" + (i + 1).ToString());
        }
    }
    void UsePieMenu()
    {
        //展示放射菜单
        //
        if (PublicVariables.TabDown)
        {
            canvasgroup.alpha = 1;
            MouseX = (int)(Input.mousePosition.x - Screen.width / 2f);
            MouseY = (int)(Input.mousePosition.y - Screen.height / 2f);
            if (Mathf.Abs(MouseX) >= 80 || Mathf.Abs(MouseY) >= 80)
            {
                K = ((int)(180 * Mathf.Atan2(MouseY, MouseX) / Mathf.PI) + 180) / 60;
                ImageOfPieMenu.sprite = temp[K % 6];
            }
            else
            {
                ImageOfPieMenu.sprite = temp[6];
            }
        }
        else
        {
            canvasgroup.alpha = 0;

        }

        //
    }

    //操作鼠标指针
    //
    void MousePointer()
    {
        //Pie Menu
        //
        if (PublicVariables.TabDown)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;

        }


    }
}
