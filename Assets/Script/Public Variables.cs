using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Public;

namespace Public
{
    public enum mouse_status { Locked, Freedom };
}


public class PublicVariables
{
    internal static Ray ray;
    internal static bool TabDown = false;
    internal static int Mode = 0;
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


internal class SimpleFunction
{
    /// <summary>
    /// 将鼠标指针在Locked和Freedom切换
    /// </summary>
    /// <param name="destination">
    /// 切换的目的状态 
    /// </param>
    public static void Mouse_Point_Converter(mouse_status destination)
    {
        if(destination == mouse_status.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }else if(destination == mouse_status.Freedom)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}