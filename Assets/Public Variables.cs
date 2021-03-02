using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicVariables
{
    public static int globle = 1;
    internal static bool TabDown = false;
}
public class BaseSetting
{
    public static float MouseSensitivity  = 20;
    public static float MoveSpeed;
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