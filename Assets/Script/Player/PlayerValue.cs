using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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