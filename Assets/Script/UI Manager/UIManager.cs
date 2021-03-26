using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
internal enum GameState
{
    Pause, Bag, Death, Normal
}
public class UIManager : MonoBehaviour
{
    // 放射菜单的变量
    //
    internal int K;
    internal Image ImageOfPieMenu;
    public Canvas MainUI;
    public Canvas PauseUI;
    public Canvas BagUI;

    //
    //
    internal GameState game_state = GameState.Normal;

    void Start()
    {

        MainUI = GameObject.Find("UI").transform.Find("Main UI").gameObject.GetComponent<Canvas>();
        PauseUI = GameObject.Find("UI").transform.Find("Pause UI").gameObject.GetComponent<Canvas>();
        BagUI = GameObject.Find("UI").transform.Find("Bag UI").gameObject.GetComponent<Canvas>();
        LoadPieMenuSprite();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            PublicVariables.TabDown = true;
        }
        else
        {
            PublicVariables.TabDown = false;

        }
        //MousePointer();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Change();
        }

    }

    /// <summary>
    /// UI上不同界面的操作函数



    //操作鼠标指针
    //


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
    private void Change()
    {
        if (game_state == GameState.Normal)
        {

            Time.timeScale = 0;
            MainUI.gameObject.SetActive(false);
            PublicVariables.Mode = 1;
            Cursor.lockState = CursorLockMode.Confined;
            BagUI.gameObject.SetActive(true);
            game_state = GameState.Bag;
        }
        else if (game_state == GameState.Bag)
        {
            Time.timeScale = 1;
            MainUI.gameObject.SetActive(true);
            BagUI.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            game_state = GameState.Normal;


        }
    }

    ///<summary>
    ///Refactor code
    ///</summary>


    internal void Mouse_Pointer_Changer()
    {//使鼠标状态在锁定与自由间切换
        if (Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


}
