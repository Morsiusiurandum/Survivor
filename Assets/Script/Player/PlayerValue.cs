using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
public enum PlayerCondition { Walk, Run, Stand };
internal class PlayerValue
{
    internal static PlayerCondition Player_Condition = PlayerCondition.Stand;

    internal static float Player_Walk_Speed = 2;
    internal static float Player_Run_Speed = 5;
    internal static float Player_Hunger_Value = 0;
    internal static float Player_Temperature_Value = 36.5f;
    internal static float Player_Thirst_Value = 0;
    internal static float Player_Willpower_Value = 100;
    internal static float Player_Strength_Value = 100;

    internal static List<item> props_value;
}
internal class Function
{
    static void WRITE(string json, string path)
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

   /* static T READ<T>(string path)
    {
        try
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string SaveJson;
                while ((SaveJson = sr.ReadLine()) != null)
                {
                    return JsonUtility.FromJson<T>(SaveJson);
                }
            }
        }
        catch (Exception exception)
        {
            Debug.Log(exception.Message);
        }
    }*/
}