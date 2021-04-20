using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Mors;
using System;

namespace Mors
{
    public enum MouseStatus { Locked, Freedom };

    public enum GameStatus { Main, Bag, Pause };

    public enum GameCanvas { PauseUI, MainUI, BagUI };

    public enum PlayerCondition { Walk, Run, Stand };

    public enum PlayerBuff { };

    [Serializable]
    class SerializeDictionary
    {
        [SerializeField]
        internal Dictionary<string, string> warped_data;
    }

    [Serializable]
    class PublicSerialize
    {
        private List<string> dictionary_t_ket;
        private List<string> dictionary_t_value;
        private List<item> props;

        PublicSerialize(List<item> data)
        {
            
        }
        PublicSerialize(Dictionary<string,string> data)
        {

        }

        /*internal List<item> Data_Back()
        {

            return;
        }
        internal Dictionary<string, string> Data_Back()
        {

            return;
        }*/

    }
}

[SerializeField]
internal class PlayerData
{
    internal static PlayerCondition player_condition = PlayerCondition.Stand;
    internal static float player_walk_speed = 2f;
    internal static float player_run_speed = 5f;
    internal static float Player_Hunger_Value = 0;
    internal static float Player_Temperature_Value = 36.5f;
    internal static float Player_Thirst_Value = 0;
    internal static float Player_Willpower_Value = 100;
    internal static float Player_Strength_Value = 100;


    internal static float player_hunger_speed = 10;
    internal static List<item> props_value;

    internal static List<PlayerBuff> buff_list;
}

public class PublicVariables
{
    internal static Ray ray;
    internal static bool TabDown = false;
}

internal class BaseSetting
{
    internal static float MouseSensitivity = 200;
}

public class BaseFunction
{
    public static void StopOrContinu()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}

internal class GameGlobalVariables
{
    internal static GameStatus game_status = GameStatus.Main;

    internal static GameCanvas game_canavs = GameCanvas.MainUI;

    internal static MouseStatus mouse_status = MouseStatus.Locked;

}

internal class SimpleFunction
{
    /// <summary>
    /// 将鼠标指针在Locked和Freedom切换
    /// </summary>
    /// <param name="destination">
    /// 切换的目的状态 
    /// </param>
    public static void Mouse_Point_Converter(MouseStatus destination)
    {
        if (destination == MouseStatus.Locked)
        {
            GameGlobalVariables.mouse_status = MouseStatus.Locked;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (destination == MouseStatus.Freedom)
        {
            GameGlobalVariables.mouse_status = MouseStatus.Freedom;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    /// <summary>
    /// 将Json文件写入文件中
    /// </summary>
    /// <param name="json">
    ///要写入的Json字段 
    /// </param>
    /// <param name="path">
    /// 目的文件地址
    /// </param>
    internal static void Json_Write(string json, string path)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(json);
            }
        }
        catch (Exception exceptione)
        {

            Debug.Log(exceptione.Message);
        }
    }

    /// <summary>
    /// 从文件中读出Json字段
    /// </summary>
    /// <param name="path">
    /// Json读取地址
    /// </param>
    /// <returns>
    /// 正常返回读取的Json，否则返回Null
    /// </returns>
    internal static string Json_Read(string path)
    {
        try
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string Json_Save;
                while ((Json_Save = sr.ReadLine()) != null)
                {
                    return Json_Save;
                    // return JsonUtility.FromJson<T>(Json_Save);
                }
            }
        }
        catch (Exception exception)
        {
            Debug.Log(exception.Message);
        }


        return null;
    }
}

internal class KeyboardManager
{

}

internal class GameComponent
{

}