using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicVariables
{
    internal static bool TabDown = false;
    internal static int Mode = 0;
}
internal class BaseSetting
{
    internal static float MouseSensitivity  = 200;
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