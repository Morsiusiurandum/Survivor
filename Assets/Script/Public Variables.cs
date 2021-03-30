using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumNamespcae;

namespace EnumNamespcae
{
    public enum MouseStatus { Locked, Freedom };

    public enum GameStatus { Main, Bag, Pause };

    public enum GameCanvas { PauseUI, MainUI, BagUI };

    public enum PlayerCondition { Walk, Run, Stand };

}


[SerializeField]
internal class PlayerValue
{
    internal static PlayerCondition player_condition = PlayerCondition.Stand;

    internal static float player_walk_speed = 2f;
    internal static float player_run_speed = 5f;
    
    

    internal static float Player_Walk_Speed = 2;
    internal static float Player_Run_Speed = 5;
    internal static float Player_Hunger_Value = 0;
    internal static float Player_Temperature_Value = 36.5f;
    internal static float Player_Thirst_Value = 0;
    internal static float Player_Willpower_Value = 100;
    internal static float Player_Strength_Value = 100;

    internal static List<item> props_value;
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
internal class GlobalVariables
{
    internal static GameStatus game_status;
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
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (destination == MouseStatus.Freedom)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

}


