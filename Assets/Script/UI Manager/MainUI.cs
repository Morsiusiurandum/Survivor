using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    //放射菜单变量
    internal Sprite[] pie_menu_sprite = new Sprite[7];
    internal Image pie_menu_image;
    internal float mouse_x, mouse_y;
    internal byte pie_menu_area;


    void Start()
    {
        Load_Pie_Menu_Sprite();
    }

    void Update()
    {

    }
    ///<summary>
    ///加载放射菜单的精灵
    ///</summary>
    internal void Load_Pie_Menu_Sprite()
    {
        
        for (int i = 0; i < 7; i++)
        {
            pie_menu_sprite[i] = Resources.Load<Sprite>("Material/temp" + (i + 1).ToString());
        }
    }

    internal void Show_Pie_Menu(bool meet_condition)
    {//展示放射菜单

        if (meet_condition)
        {
            pie_menu_image.color = new Color(255, 255, 255, 255);
            mouse_x = (int)(Input.mousePosition.x - Screen.width / 2f);
            mouse_y = (int)(Input.mousePosition.y - Screen.height / 2f);
            if (Mathf.Abs(mouse_x) >= 80 || Mathf.Abs(mouse_y) >= 80)
            {
                pie_menu_area = (byte)((180 + (180 * Mathf.Atan2(mouse_y, mouse_x) / Mathf.PI)) / 60);
                pie_menu_image.sprite = pie_menu_sprite[pie_menu_area % 6];
            }
            else
            {
                pie_menu_image.sprite = pie_menu_sprite[6];
            }
        }
        else
        {
            pie_menu_image.color = new Color(255, 255, 255, 0);
        }
    }

}
