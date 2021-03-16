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
    internal Image ImageOfPieMenu;
    public Canvas MainUI;
    public Canvas PauseUI;
    public Canvas BagUI;

    //
    //


    void Start()
    {

        MainUI = GameObject.Find("UI").transform.Find("Main UI").gameObject.GetComponent<Canvas>();
        PauseUI = GameObject.Find("UI").transform.Find("Pause UI").gameObject.GetComponent<Canvas>();
        BagUI = GameObject.Find("UI").transform.Find("Bag UI").gameObject.GetComponent<Canvas>();
        PieMenu = GameObject.Find("UI/Main UI").transform.Find("Pie Menu").gameObject;
        ImageOfPieMenu = PieMenu.GetComponent<Image>();
        LoadPieMenuSprite();
    }
    void Update()
    {
        UsePieMenu();
        MousePointer();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Change(KeyCode.B);
        }

    }

    /// <summary>
    /// UI上不同界面的操作函数

    //PieMenu
    void LoadPieMenuSprite()
    {
        for (int i = 0; i < 7; i++)
        {
            temp[i] = Resources.Load<Sprite>("Material/Pie Menu/temp" + (i + 1).ToString());
        }
    }
    void UsePieMenu()
    {
        //展示放射菜单
        //
        if (PublicVariables.TabDown)
        {
            PieMenu.SetActive(true);
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
            PieMenu.SetActive(false);


        }

        //
    }

    //操作鼠标指针
    //
    void MousePointer()
    {
        //Pie Menu
        //
        if (PublicVariables.Mode == 0)
        {
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

    //Pause Button
    void Pause()
    {
        Time.timeScale = 0;
        PublicVariables.Mode = 1;
        Cursor.lockState = CursorLockMode.Confined;
        PauseUI.gameObject.SetActive(true);
        MainUI.gameObject.SetActive(false);
    }
    public void Continue()
    {
        Time.timeScale = 1;
        PublicVariables.Mode = 0;
        Cursor.lockState = CursorLockMode.Locked;
        PauseUI.gameObject.SetActive(false);
        MainUI.gameObject.SetActive(true);

    }

    //Change UI
    private void Change(KeyCode get)
    {
        if (get == KeyCode.B)
        {
           Time.timeScale = 0;
            MainUI.gameObject.SetActive(false);
            PublicVariables.Mode = 1;
            Cursor.lockState = CursorLockMode.Confined;
            BagUI.gameObject.SetActive(true);
        }
    }
}
